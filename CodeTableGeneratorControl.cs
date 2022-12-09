using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using XrmToolBox.Extensibility;
using Label = Microsoft.Xrm.Sdk.Label;
using StringFormat = Microsoft.Xrm.Sdk.Metadata.StringFormat;
using TreeNode = System.Windows.Forms.TreeNode;

namespace CodeTableGenerator
{
    public partial class CodeTableGeneratorControl : PluginControlBase
    {
        private Dictionary<string, Guid> solutions;
        private string tableLabel, tableDesc, tableSchema, prefix, solution, primaryLabel, primarySchema, codeLabel, codeSchema, codeDataType, descLabel, descSchema, descDataType, schemaFormat;
        private readonly int LanguageCode = 1033;
        private int primaryLength, codeLength, descLength;
        private int primaryReq, codeReq, descReq;
        private bool populateForm, populateViews;
        EntityMetadata EntityMetaData;
        List<string> tables;

        public CodeTableGeneratorControl()
        {
            InitializeComponent();
        }

        private void CodeTableGeneratorControl_Load(object sender, EventArgs e)
        {
            primaryLength = 100;
            codeLength = 100;
            descLength = 2000;

            solutions = new Dictionary<string, Guid>();
            lst_Format.SetSelected(0, true);

            tables = new List<string>();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void box_CodeDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePreview();
            num_CodeLength.Enabled = box_CodeDataType.SelectedItem.ToString() == "Single Line of Text" ? true : false;
        }

        private void box_DescDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePreview();
            num_DescLength.Maximum = box_DescDataType.SelectedItem.ToString() == "Single Line of Text" ? 4000 : 1048576;
        }

        private void DigestForm()
        {
            schemaFormat = lst_Format.SelectedIndex > -1 ? lst_Format.SelectedItem.ToString() : string.Empty;

            tableLabel = txt_TableName.Text;
            tableSchema = ApplySelectedFormat(tableLabel);
            tableDesc = txt_TableDesc.Text;
            solution = box_Solution.Text;

            primaryLabel = txt_PrimaryCol.Text;
            primarySchema = ApplySelectedFormat(primaryLabel);
            primaryLength = (int)num_PrimaryLength.Value;

            codeLabel = txt_Code.Text;
            codeSchema = ApplySelectedFormat(codeLabel);
            codeDataType = box_CodeDataType.Text;
            codeLength = (int)num_CodeLength.Value;

            descLabel = txt_Desc.Text;
            if (!string.IsNullOrEmpty(descLabel))
            {                
                descSchema = ApplySelectedFormat(descLabel);
                descDataType = box_DescDataType.Text;
                descLength = (int)num_DescLength.Value;
            }            

            if (box_PrimaryReq.SelectedIndex > -1) primaryReq = box_PrimaryReq.SelectedIndex == 0 ? 0 : box_PrimaryReq.SelectedIndex + 1;
            if (box_CodeReq.SelectedIndex > -1) codeReq = box_CodeReq.SelectedIndex == 0 ? 0 : box_CodeReq.SelectedIndex + 1;
            if (box_DescReq.SelectedIndex > -1) descReq = box_DescReq.SelectedIndex == 0 ? 0 : box_DescReq.SelectedIndex + 1;

            populateForm = chk_PopulateForm.Checked;
            populateViews = chk_PopulateViews.Checked;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_TableName.Text) && !string.IsNullOrEmpty(box_Solution.Text) &&
                !string.IsNullOrEmpty(txt_Code.Text) && !string.IsNullOrEmpty(box_CodeDataType.Text) && !string.IsNullOrEmpty(box_CodeReq.Text) &&
                (string.IsNullOrEmpty(txt_Desc.Text) || (!string.IsNullOrEmpty(txt_Desc.Text) && !string.IsNullOrEmpty(box_DescDataType.Text))) &&
                lst_Format.SelectedItem != null && !string.IsNullOrEmpty(txt_PrimaryCol.Text) && !string.IsNullOrEmpty(box_PrimaryReq.Text))
            {
                DisableInputs();
                DigestForm();

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Creating table...",
                    Work = (w, e2) =>
                    {
                        // This code is executed in another thread
                        ExecuteMethod(CreateTable);

                        w.ReportProgress(-1, "Table created.");
                        e2.Result = 1;
                    },
                    ProgressChanged = e2 =>
                    {
                        SetWorkingMessage(e2.UserState.ToString());
                    },
                    PostWorkCallBack = e2 =>
                    {
                        // This code is executed in the main thread
                        if (populateForm)
                        {
                            DisableInputs();
                            WorkAsync(new WorkAsyncInfo
                            {
                                Message = "Populating forms...",
                                Work = (w, e3) =>
                                {
                                    // This code is executed in another thread
                                    PopulateForms(EntityMetaData);
                                    e3.Result = 1;
                                },
                                ProgressChanged = e3 =>
                                {
                                    SetWorkingMessage(e3.UserState.ToString());
                                },
                                PostWorkCallBack = e3 =>
                                {
                                    // This code is executed in the main thread
                                    if (populateViews)
                                    {
                                        ExecuteMethodAsync(PopulateViews, "Populating views...");
                                    }
                                    else EnableInputs();
                                },
                                AsyncArgument = null,
                                // Progress information panel size
                                MessageWidth = 340,
                                MessageHeight = 150
                            });
                        }
                        else if (populateViews) ExecuteMethodAsync(PopulateViews, "Populating views...");
                        else EnableInputs();

                        tables.Add(tableSchema.ToLower());
                    },
                    AsyncArgument = null,
                    // Progress information panel size
                    MessageWidth = 340,
                    MessageHeight = 150
                });
            }
            else
            {
                MessageBox.Show("Please fill in all required (*) inputs.");
            }
        }

        private void ExecuteMethodAsync(Action method, string message)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = message,
                Work = (w, e) =>
                {
                    // This code is executed in another thread
                    ExecuteMethod(method);

                    e.Result = 1;
                },
                ProgressChanged = e =>
                {
                    SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = e =>
                {
                    // This code is executed in the main thread
                    EnableInputs();
                },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void PopulatePreview()
        {
            tree_Preview.Nodes.Clear();
            DigestForm();

            string tableNodeLabel = tableLabel;
            tableNodeLabel += !string.IsNullOrEmpty(tableSchema) ? $" ({tableSchema})" : string.Empty;

            TreeNode tableNode = new TreeNode(tableNodeLabel);

            if (!string.IsNullOrEmpty(primaryLabel))
            {
                string primaryNodeLabel = primaryLabel;
                primaryNodeLabel += !string.IsNullOrEmpty(primarySchema) ? $" ({primarySchema})" : string.Empty;
                primaryNodeLabel += primaryReq == 2 ? "*" : string.Empty;

                TreeNode primaryNode = new TreeNode(primaryNodeLabel);
                primaryNode.Nodes.Add(new TreeNode($"Data Type: Single Line of Text"));

                if (primaryLength != 0)
                {
                    primaryNode.Nodes.Add(new TreeNode($"Length: {primaryLength}"));
                }

                tableNode.Nodes.Add(primaryNode);
            }

            if (!string.IsNullOrEmpty(codeLabel))
            {
                string codeNodeLabel = codeLabel;
                codeNodeLabel += !string.IsNullOrEmpty(codeSchema) ? $" ({codeSchema})" : string.Empty;
                codeNodeLabel += codeReq == 2 ? "*" : string.Empty;
                
                TreeNode codeNode = new TreeNode(codeNodeLabel);

                if (!string.IsNullOrEmpty(codeDataType))
                {
                    codeNode.Nodes.Add(new TreeNode($"Data Type: {codeDataType}"));
                }

                if (codeLength != 0)
                {
                    codeNode.Nodes.Add(new TreeNode($"Length: {codeLength}"));
                }

                tableNode.Nodes.Add(codeNode);
            }

            if (!string.IsNullOrEmpty(descLabel))
            {
                string descNodeLabel = descLabel;
                descNodeLabel += !string.IsNullOrEmpty(descSchema) ? $" ({descSchema})" : string.Empty;
                descNodeLabel += descReq == 2 ? "*" : string.Empty;

                TreeNode descNode = new TreeNode(descNodeLabel);

                if (!string.IsNullOrEmpty(descDataType))
                {
                    descNode.Nodes.Add(new TreeNode($"Data Type: {descDataType}"));
                }

                if (descLength != 0)
                {
                    descNode.Nodes.Add(new TreeNode($"Length: {descLength}"));
                }

                tableNode.Nodes.Add(descNode);
            }

            tree_Preview.Nodes.Add(tableNode);
            tree_Preview.ExpandAll();
        }

        private void DisableInputs()
        {
            box_Solution.Enabled = false;
            txt_TableName.Enabled = false;            
            txt_TableDesc.Enabled = false;

            txt_PrimaryCol.Enabled = false;
            num_PrimaryLength.Enabled = false;
            box_PrimaryReq.Enabled = false;

            txt_Code.Enabled = false;
            txt_Desc.Enabled = false;
            box_CodeDataType.Enabled = false;
            box_DescDataType.Enabled = false;
            num_CodeLength.Enabled = false;
            num_DescLength.Enabled = false;
            box_CodeReq.Enabled = false;
            box_DescReq.Enabled = false;

            lst_Format.Enabled = false;
            chk_PopulateForm.Enabled = false;
            chk_PopulateViews.Enabled = false;

            btn_Create.Enabled = false;
            btn_Publish.Enabled = false;
        }

        private void EnableInputs()
        {
            box_Solution.Enabled = true;
            txt_TableName.Enabled = true;
            txt_TableDesc.Enabled = true;

            txt_PrimaryCol.Enabled = true;
            num_PrimaryLength.Enabled = true;
            box_PrimaryReq.Enabled = true;

            txt_Code.Enabled = true;
            txt_Desc.Enabled = true;
            box_CodeDataType.Enabled = true;
            box_DescDataType.Enabled = true;
            num_CodeLength.Enabled = true;
            num_DescLength.Enabled = true;
            box_CodeReq.Enabled = true;
            box_DescReq.Enabled = true;

            lst_Format.Enabled = true;
            chk_PopulateForm.Enabled = true;
            chk_PopulateViews.Enabled = true;

            btn_Create.Enabled = true;
            btn_Publish.Enabled = true;
        }

        private static string RemovePunctuations(string source)
        {
            return Regex.Replace(source, @"[^\w]", string.Empty);
        }

        private void btn_Publish_Click(object sender, EventArgs e)
        {
            ExecuteMethod(PublishCustomizations);
        }

        private void txt_TableName_TextChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void txt_Code_TextChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void txt_PrimaryCol_TextChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void num_PrimaryLength_ValueChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void box_CodeReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void box_DescReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void lst_Format_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void box_Solution_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, Guid> solutionKVP = solutions.FirstOrDefault(x => x.Key == box_Solution.Text);

            if (solutionKVP.Key != null)
            {
                RetrievePublisher(solutionKVP.Value);
                PopulatePreview();
            }
        }

        private void box_PrimaryReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void num_CodeLength_ValueChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void txt_Desc_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Desc.Text))
            {
                if (!lbl_DescDataType.Text.Contains(" *")) lbl_DescDataType.Text += " *";
                if (!lbl_DescDataLength.Text.Contains(" *")) lbl_DescDataLength.Text += " *";
                if (!lbl_DescReq.Text.Contains(" *")) lbl_DescReq.Text += " *";
            }
            else
            {
                lbl_DescDataType.Text = lbl_DescDataType.Text.Replace(" *", string.Empty);
                lbl_DescDataLength.Text = lbl_DescDataLength.Text.Replace(" *", string.Empty);
                lbl_DescReq.Text = lbl_DescReq.Text.Replace(" *", string.Empty);
            }

            PopulatePreview();
        }

        private void num_DescLength_ValueChanged(object sender, EventArgs e)
        {
            PopulatePreview();
        }

        private void CreateTable()
        {
            string tableLabelPlural;

            if (tableLabel.EndsWith("s"))
            {
                tableLabelPlural = tableLabel + "es";
            }
            else if (Regex.IsMatch(tableLabel, "\b.*(a|e|i|o|u)y\b"))
            {
                tableLabelPlural = tableLabel + "s";
            }
            else if (tableLabel.EndsWith("y"))
            {
                tableLabelPlural = tableLabel.Substring(0, tableLabel.Length - 1) + "ies";
            }
            else
            {
                tableLabelPlural = tableLabel + "s";
            }

            EntityMetaData = RetrieveEntityMetaData();
            if (EntityMetaData == null)
            {
                try
                {
                    CreateEntityRequest createrequest = new CreateEntityRequest
                    {
                        //Define the entity
                        Entity = new EntityMetadata
                        {
                            SchemaName = tableSchema,
                            DisplayName = new Label(tableLabel, LanguageCode),
                            DisplayCollectionName = new Label(tableLabelPlural, LanguageCode),
                            Description = new Label(tableDesc, LanguageCode),
                            OwnershipType = OwnershipTypes.UserOwned,
                            IsActivity = false,
                            HasNotes = true
                        },

                        // Define the primary attribute for the entity
                        PrimaryAttribute = new StringAttributeMetadata
                        {
                            SchemaName = primarySchema,
                            RequiredLevel = new AttributeRequiredLevelManagedProperty((AttributeRequiredLevel)primaryReq),
                            MaxLength = primaryLength,
                            FormatName = StringFormatName.Text,
                            DisplayName = new Label(primaryLabel, LanguageCode),
                            Description = new Label("The primary attribute for the " + tableLabel + " table.", LanguageCode)
                        },

                        SolutionUniqueName = solution
                    };

                    Service.Execute(createrequest);

                    EntityMetaData = RetrieveEntityMetaData(); // retrieve newly created entity

                    if (EntityMetaData != null)
                    {
                        // code field
                        if (codeDataType == "Single Line of Text")
                        {
                            CreateSingleLineAttribute(codeSchema, codeLabel, codeLength, codeReq);
                        }
                        else if (codeDataType == "Whole Number")
                        {
                            CreateWholeNumberAttribute(codeSchema, codeLabel, codeReq);
                        }

                        // description field
                        if (!string.IsNullOrEmpty(txt_Desc.Text))
                        {
                            if (descDataType == "Single Line of Text")
                            {
                                CreateSingleLineAttribute(descSchema, descLabel, descLength, descReq);
                            }
                            else if (descDataType == "Multiple Lines of Text")
                            {
                                CreateMemoAttribute(descSchema, descLabel, descLength, descReq);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show($"The {tableLabel} table already exists.");
            }
        }

        private string ApplySelectedFormat(string source)
        {
            switch (schemaFormat)
            {
                case "camelCase":
                    source = prefix + RemovePunctuations(ToCamelCase(source));
                    break;
                case "lowercase":
                    source = prefix + RemovePunctuations(source).ToLower();
                    break;
                case "PascalCase":
                    source = prefix + RemovePunctuations(source);
                    break;
                case "UPPERCASE":
                    source = prefix + RemovePunctuations(source).ToUpper();
                    break;
                default: break;
            }

            return source;
        }

        private string ToCamelCase(string source)
        {
            if (source.Contains(" ")) source = source.Split(' ')[0].ToLower() + string.Join(string.Empty, source.Split(' ').Skip(1).ToArray()).Replace(" ", string.Empty);
            else source = source.ToLower();

            return source;
        }

        private void CreateSingleLineAttribute(string fieldSchema, string fieldLabel, int length, int required)
        {
            CreateAttributeRequest CreateAttributeRequest = new CreateAttributeRequest
            {
                EntityName = tableSchema.ToLower(),
                Attribute = new StringAttributeMetadata
                {
                    SchemaName = fieldSchema,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty((AttributeRequiredLevel)required),
                    FormatName = StringFormatName.Text,
                    DisplayName = new Label(fieldLabel, LanguageCode),
                    MaxLength = length
                },
                SolutionUniqueName = solution
            };

            Service.Execute(CreateAttributeRequest);
        }

        private void CreateMemoAttribute(string fieldSchema, string fieldLabel, int length, int required)
        {
            CreateAttributeRequest CreateAttributeRequest = new CreateAttributeRequest
            {
                EntityName = tableSchema.ToLower(),
                Attribute = new MemoAttributeMetadata
                {
                    SchemaName = fieldSchema,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty((AttributeRequiredLevel)required),
                    Format = StringFormat.TextArea,
                    DisplayName = new Label(fieldLabel, LanguageCode),
                    MaxLength = length
                },
                SolutionUniqueName = solution
            };

            Service.Execute(CreateAttributeRequest);
        }

        private void CreateWholeNumberAttribute(string fieldSchema, string fieldLabel, int required)
        {
            CreateAttributeRequest CreateAttributeRequest = new CreateAttributeRequest
            {
                EntityName = tableSchema.ToLower(),
                Attribute = new IntegerAttributeMetadata
                {
                    SchemaName = fieldSchema,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty((AttributeRequiredLevel)required),
                    DisplayName = new Label(fieldLabel, LanguageCode),
                    MaxValue = IntegerAttributeMetadata.MaxSupportedValue,
                    MinValue = IntegerAttributeMetadata.MinSupportedValue
                },
                SolutionUniqueName = solution
            };

            Service.Execute(CreateAttributeRequest);
        }

        private EntityMetadata RetrieveEntityMetaData()
        {
            try
            {
                RetrieveEntityRequest req = new RetrieveEntityRequest()
                {
                    EntityFilters = EntityFilters.Attributes,
                    LogicalName = tableSchema.ToLower()
                };
                return (Service.Execute(req) as RetrieveEntityResponse).EntityMetadata;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void RetrieveSolutions()
        {
            solutions.Clear();

            QueryExpression query = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet = new ColumnSet("uniquename", "publisherid"),
                Criteria = new FilterExpression()
            };

            query.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);

            try
            {
                foreach (Entity solution in Service.RetrieveMultiple(query).Entities)
                {
                    if (solution["uniquename"].ToString() != "System" && solution["uniquename"].ToString() != "Active" && solution["uniquename"].ToString() != "Basic" && solution["uniquename"].ToString() != "ActivityFeeds" && !string.IsNullOrEmpty(solution["publisherid"].ToString()))
                    {
                        solutions.Add(solution["uniquename"].ToString(), solution.GetAttributeValue<EntityReference>("publisherid").Id);
                        box_Solution.Items.Add(solution["uniquename"]);
                    }
                }
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void RetrievePublisher(Guid publisherId)
        {
            QueryByAttribute query = new QueryByAttribute
            {
                EntityName = "publisher",
                ColumnSet = new ColumnSet("customizationprefix")
            };

            query.Attributes.Add("publisherid");
            query.Values.Add(publisherId);

            try
            {
                EntityCollection retrievedPublishers = Service.RetrieveMultiple(query);

                if (retrievedPublishers.Entities.Count > 0)
                {
                    prefix = retrievedPublishers.Entities[0]["customizationprefix"].ToString() + "_";
                }
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void box_Solution_Click(object sender, EventArgs e)
        {
            box_Solution.Items.Clear();
            RetrieveSolutions();
        }
        
        private void PublishCustomizations()
        {
            DisableInputs();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Publishing customizations...",
                Work = (w, e) =>
                {
                    // This code is executed in another thread
                    PublishXmlRequest PublishRequest = new PublishXmlRequest
                    {
                        ParameterXml = "<importexportxml><entities><entity>" + string.Join("</entity><entity>", tables.ToArray()) + "</entity></entities></importexportxml>"
                    };
                    Service.Execute(PublishRequest);

                    w.ReportProgress(-1, "Publishing complete.");
                    e.Result = 1;
                },
                ProgressChanged = e =>
                {
                    SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = e =>
                {
                    // This code is executed in the main thread
                    tables.Clear();
                    EnableInputs();
                },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });
            
        }

        private void PopulateForms(EntityMetadata entityMetadata)
        {
            try
            {
                QueryByAttribute query = new QueryByAttribute
                {
                    EntityName = "systemform",
                    ColumnSet = new ColumnSet(true)
                };

                query.Attributes.Add("objecttypecode");
                query.Values.Add(entityMetadata.ObjectTypeCode.Value);

                EntityCollection forms = Service.RetrieveMultiple(query);

                foreach (Entity form in forms.Entities)
                {
                    string singleLineClassId = "{4273EDBD-AC1D-40d3-9FB2-095C621B552D}";
                    string multiLineClassId = "{E0DECE4B-6FC8-4a8f-A065-082708572369}";
                    string wholeNumberClassId = "{C6D124CA-7EDA-4a60-AEA9-7FB8D318B68F}";
                    string lookupClassId = "{270BD3DB-D9AF-4782-9025-509E298DEC0A}";
                    string selectedTypeClassId, nameRowXml, codeRowXml, descRowXml = "";

                    nameRowXml = $@"<row>
									    <cell id=""{Guid.NewGuid()}"">
										    <labels>
											    <label description=""{primaryLabel}"" languagecode=""1033"" />
										    </labels>
										    <control id=""{primarySchema.ToLower()}"" classid=""{singleLineClassId}"" datafieldname=""{primarySchema.ToLower()}"" />
									    </cell>
								    </row>";

                    selectedTypeClassId = codeDataType == "Single Line of Text" ? singleLineClassId : wholeNumberClassId;
                    codeRowXml = $@"<row>
									    <cell id=""{Guid.NewGuid()}"">
										    <labels>
											    <label description=""{codeLabel}"" languagecode=""1033"" />
										    </labels>
										    <control id=""{codeSchema.ToLower()}"" classid=""{selectedTypeClassId}"" datafieldname=""{codeSchema.ToLower()}"" disabled=""false"" />
									    </cell>
								    </row>";

                    if (!string.IsNullOrEmpty(descLabel))
                    {
                        selectedTypeClassId = descDataType == "Single Line of Text" ? singleLineClassId : multiLineClassId;
                        descRowXml = $@"<row>
									        <cell id=""{Guid.NewGuid()}"" rowspan=""4"">
										        <labels>
											        <label description=""{descLabel}"" languagecode=""1033"" />
										        </labels>
										        <control id=""{descSchema.ToLower()}"" classid=""{selectedTypeClassId}"" datafieldname=""{descSchema.ToLower()}"" disabled=""false"" />
									        </cell>
								        </row>
                                        <row></row><row></row><row></row>";
                    }

                    string newFormXml = $@"<form>
	                                        <tabs>
		                                        <tab verticallayout=""true"" id=""{{53e0ce58-11a1-4cae-8b7b-18bf043b11bf}}"" IsUserDefined=""1"">
			                                        <labels>
				                                        <label description=""General"" languagecode=""1033"" />
			                                        </labels>
			                                        <columns>
				                                        <column width=""100%"">
					                                        <sections>
						                                        <section showlabel=""false"" showbar=""false"" IsUserDefined=""0"" id=""{{040bf044-8765-4f89-8f17-1ed5e18e5f93}}"">
							                                        <labels>
								                                        <label description=""General"" languagecode=""1033"" />
							                                        </labels>
							                                        <rows>
								                                        {nameRowXml}
								                                        {codeRowXml}
                                                                        {descRowXml}
                                                                        <row>
									                                        <cell id=""{Guid.NewGuid()}"">
										                                        <labels>
											                                        <label description=""Owner"" languagecode=""1033"" />
										                                        </labels>
										                                        <control id=""ownerid"" classid=""{lookupClassId}"" datafieldname=""ownerid"" />
									                                        </cell>
								                                        </row>
                                                                    </rows>
						                                        </section>
					                                        </sections>
				                                        </column>
			                                        </columns>
		                                        </tab>
	                                        </tabs>
                                        </form>";

                    XmlDocument formLayout = new XmlDocument();
                    formLayout.LoadXml(form["formxml"].ToString());

                    string rowsPath = "form/tabs/tab/columns/column/sections/section/rows";

                    for (int i = formLayout.SelectSingleNode(rowsPath).ChildNodes.Count; i > 0; i--)
                    {
                        XmlNode toDelete = formLayout.SelectSingleNode(rowsPath).ChildNodes[i - 1];
                        formLayout.SelectSingleNode(rowsPath).RemoveChild(toDelete);
                    }

                    XmlDocument newFormXmlDoc = new XmlDocument();
                    newFormXmlDoc.LoadXml(newFormXml);

                    XmlNodeList newFormRowNodes = newFormXmlDoc.SelectNodes(rowsPath+"/row");

                    foreach (XmlNode rowNode in newFormRowNodes)
                    {
                        XmlNode nodeDest = formLayout.ImportNode(rowNode.Clone(), true);
                        formLayout.SelectSingleNode(rowsPath).AppendChild(nodeDest);
                    }

                    form["name"] = tableLabel;
                    form["formxml"] = formLayout.OuterXml;

                    Service.Update(form);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while populating form: " + ex.Message);
            }
        }

        private void PopulateViews()
        {
            string descriptionCell = string.IsNullOrEmpty(descLabel) ? string.Empty : $"<cell name='{descSchema.ToLower()}' width='300' />";

            string newLayout = $@"<grid name='resultset' object='{EntityMetaData.ObjectTypeCode.Value}' jump='{primarySchema.ToLower()}' select='1' preview='1' icon='1'>
                                                    <row name='result' id='{tableSchema.ToLower()}id'>
                                                        <cell name='{primarySchema.ToLower()}' width='150' />
                                                        <cell name='{codeSchema.ToLower()}' width='150' />
                                                        {descriptionCell}
                                                    </row>
                                                </grid>";

            XmlDocument newLayoutDoc = new XmlDocument();
            newLayoutDoc.LoadXml(newLayout);

            string descriptionAttribute = string.IsNullOrEmpty(descLabel) ? string.Empty : $"<attribute name='{descSchema.ToLower()}' /> ";

            string newFetch = $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                    <entity name='{tableSchema.ToLower()}'>
                                                        <order attribute='{primarySchema.ToLower()}' descending='false' />
                                                        <attribute name='{primarySchema.ToLower()}' />
                                                        <attribute name='{codeSchema.ToLower()}' />
                                                        {descriptionAttribute}
                                                    </entity>
                                                </fetch>";

            List<Entity> views = RetrieveViews(EntityMetaData);

            ViewDefinition view;
            foreach (Entity entity in views.Where(x => x.GetAttributeValue<string>("layoutxml") != null))
            {
                view = new ViewDefinition(entity);
                PopulateView(view, newLayoutDoc, newFetch);
            }
        }

        private void PopulateView(ViewDefinition view, XmlDocument newLayout, string newFetch)
        {
            XmlDocument targetLayout = new XmlDocument();

            targetLayout.LoadXml(view.LayoutXml);

            // clear view cells
            for (int i = targetLayout.SelectSingleNode("grid/row").ChildNodes.Count; i > 0; i--)
            {
                XmlNode toDelete = targetLayout.SelectSingleNode("grid/row").ChildNodes[i - 1];
                targetLayout.SelectSingleNode("grid/row").RemoveChild(toDelete);
            }

            XmlNodeList sourceCellNodes = newLayout.SelectNodes("grid/row/cell");

            foreach (XmlNode cellNode in sourceCellNodes)
            {
                if (!cellNode.Attributes["name"].Value.Contains(".") || view.Type != 2) // 2 : VIEW_ASSOCIATED
                {
                    XmlNode nodeDest = targetLayout.ImportNode(cellNode.Clone(), true);
                    targetLayout.SelectSingleNode("grid/row").AppendChild(nodeDest);
                }
            }

            view.LayoutXml = targetLayout.OuterXml;

            if (!string.IsNullOrEmpty(view.FetchXml))
            {
                XmlDocument targetFetchDoc = new XmlDocument();
                targetFetchDoc.LoadXml(view.FetchXml);

                XmlDocument sourceFetchDoc = new XmlDocument();
                sourceFetchDoc.LoadXml(newFetch);

                XmlNodeList sourceAttrNodes = sourceFetchDoc.SelectNodes("fetch/entity/attribute");

                foreach (XmlNode attrNode in sourceAttrNodes)
                {
                    if (targetFetchDoc.SelectSingleNode("fetch/entity/attribute[@name='" + attrNode.Attributes["name"].Value + "']") == null)
                    {
                        XmlNode attrNodeToAdd = targetFetchDoc.ImportNode(attrNode, true);
                        targetFetchDoc.SelectSingleNode("fetch/entity").AppendChild(attrNodeToAdd);
                    }
                }

                foreach (XmlNode cellNode in sourceCellNodes)
                {
                    string name = cellNode.Attributes["name"].Value;
                    if (!name.Contains(".") && targetFetchDoc.SelectSingleNode("fetch/entity/attribute[@name='" + name + "']") == null)
                    {
                        XmlElement attrNodeToAdd = targetFetchDoc.CreateElement("attribute");
                        attrNodeToAdd.SetAttribute("name", name);
                        targetFetchDoc.SelectSingleNode("fetch/entity").AppendChild(attrNodeToAdd);
                    }
                }

                view.FetchXml = targetFetchDoc.OuterXml;

                try
                {
                    view.InnerRecord.Attributes.Remove("statecode");
                    view.InnerRecord.Attributes.Remove("statuscode");

                    Service.Update(view.InnerRecord);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving view: " + ex.Message);
                }
            }
        }

        private List<Entity> RetrieveViews(EntityMetadata entityMetadata)
        {
            try
            {
                QueryByAttribute query = new QueryByAttribute
                {
                    EntityName = "savedquery",
                    ColumnSet = new ColumnSet(true)
                };

                query.Attributes.Add("returnedtypecode");
                query.Values.Add(entityMetadata.ObjectTypeCode.Value);

                EntityCollection views = Service.RetrieveMultiple(query);

                List<Entity> viewsList = new List<Entity>();
                foreach (Entity entity in views.Entities)
                {
                    viewsList.Add(entity);
                }

                return viewsList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving views: " + ex.Message);
            }
        }
    }
}