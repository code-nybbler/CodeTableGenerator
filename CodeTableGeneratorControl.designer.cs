namespace CodeTableGenerator
{
    partial class CodeTableGeneratorControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txt_TableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Desc = new System.Windows.Forms.TextBox();
            this.lbl_DescDataType = new System.Windows.Forms.Label();
            this.box_DescDataType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.box_CodeDataType = new System.Windows.Forms.ComboBox();
            this.num_DescLength = new System.Windows.Forms.NumericUpDown();
            this.num_CodeLength = new System.Windows.Forms.NumericUpDown();
            this.lbl_DescDataLength = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lst_Format = new System.Windows.Forms.ListBox();
            this.tree_Preview = new System.Windows.Forms.TreeView();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Create = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_TableDesc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.box_Solution = new System.Windows.Forms.ComboBox();
            this.btn_Publish = new System.Windows.Forms.Button();
            this.chk_PopulateForm = new System.Windows.Forms.CheckBox();
            this.chk_PopulateViews = new System.Windows.Forms.CheckBox();
            this.lbl_DescReq = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.box_DescReq = new System.Windows.Forms.ComboBox();
            this.box_CodeReq = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.num_PrimaryLength = new System.Windows.Forms.NumericUpDown();
            this.box_PrimaryReq = new System.Windows.Forms.ComboBox();
            this.txt_PrimaryCol = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_DescLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CodeLength)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_PrimaryLength)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1190, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(59, 29);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // txt_TableName
            // 
            this.txt_TableName.Location = new System.Drawing.Point(6, 52);
            this.txt_TableName.MaxLength = 30;
            this.txt_TableName.Name = "txt_TableName";
            this.txt_TableName.Size = new System.Drawing.Size(282, 26);
            this.txt_TableName.TabIndex = 0;
            this.txt_TableName.TextChanged += new System.EventHandler(this.txt_TableName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Code Column Label *";
            // 
            // txt_Code
            // 
            this.txt_Code.Location = new System.Drawing.Point(6, 52);
            this.txt_Code.MaxLength = 30;
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.Size = new System.Drawing.Size(282, 26);
            this.txt_Code.TabIndex = 8;
            this.txt_Code.Text = "Code";
            this.txt_Code.TextChanged += new System.EventHandler(this.txt_Code_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Description Column Label";
            // 
            // txt_Desc
            // 
            this.txt_Desc.Location = new System.Drawing.Point(6, 117);
            this.txt_Desc.MaxLength = 30;
            this.txt_Desc.Name = "txt_Desc";
            this.txt_Desc.Size = new System.Drawing.Size(282, 26);
            this.txt_Desc.TabIndex = 12;
            this.txt_Desc.TextChanged += new System.EventHandler(this.txt_Desc_TextChanged);
            // 
            // lbl_DescDataType
            // 
            this.lbl_DescDataType.AutoSize = true;
            this.lbl_DescDataType.Location = new System.Drawing.Point(290, 94);
            this.lbl_DescDataType.Name = "lbl_DescDataType";
            this.lbl_DescDataType.Size = new System.Drawing.Size(82, 20);
            this.lbl_DescDataType.TabIndex = 13;
            this.lbl_DescDataType.Text = "Data Type";
            // 
            // box_DescDataType
            // 
            this.box_DescDataType.FormattingEnabled = true;
            this.box_DescDataType.Items.AddRange(new object[] {
            "Single Line of Text",
            "Multiple Lines of Text"});
            this.box_DescDataType.Location = new System.Drawing.Point(294, 117);
            this.box_DescDataType.Name = "box_DescDataType";
            this.box_DescDataType.Size = new System.Drawing.Size(282, 28);
            this.box_DescDataType.TabIndex = 13;
            this.box_DescDataType.Text = "Multiple Lines of Text";
            this.box_DescDataType.SelectedIndexChanged += new System.EventHandler(this.box_DescDataType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(290, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Data Type *";
            // 
            // box_CodeDataType
            // 
            this.box_CodeDataType.FormattingEnabled = true;
            this.box_CodeDataType.Items.AddRange(new object[] {
            "Single Line of Text",
            "Whole Number"});
            this.box_CodeDataType.Location = new System.Drawing.Point(294, 52);
            this.box_CodeDataType.Name = "box_CodeDataType";
            this.box_CodeDataType.Size = new System.Drawing.Size(282, 28);
            this.box_CodeDataType.TabIndex = 9;
            this.box_CodeDataType.Text = "Single Line of Text";
            this.box_CodeDataType.SelectedIndexChanged += new System.EventHandler(this.box_CodeDataType_SelectedIndexChanged);
            // 
            // num_DescLength
            // 
            this.num_DescLength.Location = new System.Drawing.Point(582, 117);
            this.num_DescLength.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.num_DescLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_DescLength.Name = "num_DescLength";
            this.num_DescLength.Size = new System.Drawing.Size(132, 26);
            this.num_DescLength.TabIndex = 14;
            this.num_DescLength.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.num_DescLength.ValueChanged += new System.EventHandler(this.num_DescLength_ValueChanged);
            // 
            // num_CodeLength
            // 
            this.num_CodeLength.Location = new System.Drawing.Point(582, 52);
            this.num_CodeLength.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.num_CodeLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_CodeLength.Name = "num_CodeLength";
            this.num_CodeLength.Size = new System.Drawing.Size(132, 26);
            this.num_CodeLength.TabIndex = 10;
            this.num_CodeLength.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_CodeLength.ValueChanged += new System.EventHandler(this.num_CodeLength_ValueChanged);
            // 
            // lbl_DescDataLength
            // 
            this.lbl_DescDataLength.AutoSize = true;
            this.lbl_DescDataLength.Location = new System.Drawing.Point(578, 94);
            this.lbl_DescDataLength.Name = "lbl_DescDataLength";
            this.lbl_DescDataLength.Size = new System.Drawing.Size(92, 20);
            this.lbl_DescDataLength.TabIndex = 13;
            this.lbl_DescDataLength.Text = "Max Length";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(578, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Max Length *";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lst_Format);
            this.groupBox4.Location = new System.Drawing.Point(592, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(582, 124);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Schema Formatting *";
            // 
            // lst_Format
            // 
            this.lst_Format.FormattingEnabled = true;
            this.lst_Format.ItemHeight = 20;
            this.lst_Format.Items.AddRange(new object[] {
            "camelCase",
            "lowercase",
            "PascalCase",
            "UPPERCASE"});
            this.lst_Format.Location = new System.Drawing.Point(6, 25);
            this.lst_Format.Name = "lst_Format";
            this.lst_Format.Size = new System.Drawing.Size(570, 84);
            this.lst_Format.TabIndex = 7;
            this.lst_Format.SelectedIndexChanged += new System.EventHandler(this.lst_Format_SelectedIndexChanged);
            // 
            // tree_Preview
            // 
            this.tree_Preview.Location = new System.Drawing.Point(10, 470);
            this.tree_Preview.Name = "tree_Preview";
            this.tree_Preview.ShowPlusMinus = false;
            this.tree_Preview.ShowRootLines = false;
            this.tree_Preview.Size = new System.Drawing.Size(570, 282);
            this.tree_Preview.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 447);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Table Preview";
            // 
            // btn_Create
            // 
            this.btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Create.Location = new System.Drawing.Point(592, 470);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(582, 123);
            this.btn_Create.TabIndex = 18;
            this.btn_Create.Text = "Create Table";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txt_TableDesc);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.box_Solution);
            this.groupBox5.Controls.Add(this.txt_TableName);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(4, 45);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(582, 222);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Table Properties";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "Description";
            // 
            // txt_TableDesc
            // 
            this.txt_TableDesc.Location = new System.Drawing.Point(6, 123);
            this.txt_TableDesc.MaxLength = 2000;
            this.txt_TableDesc.Multiline = true;
            this.txt_TableDesc.Name = "txt_TableDesc";
            this.txt_TableDesc.Size = new System.Drawing.Size(570, 84);
            this.txt_TableDesc.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(290, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Solution *";
            // 
            // box_Solution
            // 
            this.box_Solution.FormattingEnabled = true;
            this.box_Solution.Location = new System.Drawing.Point(294, 52);
            this.box_Solution.Name = "box_Solution";
            this.box_Solution.Size = new System.Drawing.Size(282, 28);
            this.box_Solution.TabIndex = 2;
            this.box_Solution.SelectedIndexChanged += new System.EventHandler(this.box_Solution_SelectedIndexChanged);
            this.box_Solution.Click += new System.EventHandler(this.box_Solution_Click);
            // 
            // btn_Publish
            // 
            this.btn_Publish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Publish.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Publish.Location = new System.Drawing.Point(592, 629);
            this.btn_Publish.Name = "btn_Publish";
            this.btn_Publish.Size = new System.Drawing.Size(582, 123);
            this.btn_Publish.TabIndex = 19;
            this.btn_Publish.Text = "Publish Customizations";
            this.btn_Publish.UseVisualStyleBackColor = true;
            this.btn_Publish.Click += new System.EventHandler(this.btn_Publish_Click);
            // 
            // chk_PopulateForm
            // 
            this.chk_PopulateForm.AutoSize = true;
            this.chk_PopulateForm.Checked = true;
            this.chk_PopulateForm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_PopulateForm.Location = new System.Drawing.Point(6, 52);
            this.chk_PopulateForm.Name = "chk_PopulateForm";
            this.chk_PopulateForm.Size = new System.Drawing.Size(147, 24);
            this.chk_PopulateForm.TabIndex = 16;
            this.chk_PopulateForm.Text = "Populate Forms";
            this.chk_PopulateForm.UseVisualStyleBackColor = true;
            // 
            // chk_PopulateViews
            // 
            this.chk_PopulateViews.AutoSize = true;
            this.chk_PopulateViews.Checked = true;
            this.chk_PopulateViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_PopulateViews.Location = new System.Drawing.Point(6, 117);
            this.chk_PopulateViews.Name = "chk_PopulateViews";
            this.chk_PopulateViews.Size = new System.Drawing.Size(144, 24);
            this.chk_PopulateViews.TabIndex = 17;
            this.chk_PopulateViews.Text = "Populate Views";
            this.chk_PopulateViews.UseVisualStyleBackColor = true;
            // 
            // lbl_DescReq
            // 
            this.lbl_DescReq.AutoSize = true;
            this.lbl_DescReq.Location = new System.Drawing.Point(716, 94);
            this.lbl_DescReq.Name = "lbl_DescReq";
            this.lbl_DescReq.Size = new System.Drawing.Size(101, 20);
            this.lbl_DescReq.TabIndex = 5;
            this.lbl_DescReq.Text = "Requirement";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(716, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Requirement *";
            // 
            // box_DescReq
            // 
            this.box_DescReq.FormattingEnabled = true;
            this.box_DescReq.Items.AddRange(new object[] {
            "Optional",
            "Required",
            "Recommended"});
            this.box_DescReq.Location = new System.Drawing.Point(720, 117);
            this.box_DescReq.Name = "box_DescReq";
            this.box_DescReq.Size = new System.Drawing.Size(150, 28);
            this.box_DescReq.TabIndex = 15;
            this.box_DescReq.Text = "Optional";
            this.box_DescReq.SelectedIndexChanged += new System.EventHandler(this.box_DescReq_SelectedIndexChanged);
            // 
            // box_CodeReq
            // 
            this.box_CodeReq.FormattingEnabled = true;
            this.box_CodeReq.Items.AddRange(new object[] {
            "Optional",
            "Required",
            "Recommended"});
            this.box_CodeReq.Location = new System.Drawing.Point(720, 52);
            this.box_CodeReq.Name = "box_CodeReq";
            this.box_CodeReq.Size = new System.Drawing.Size(150, 28);
            this.box_CodeReq.TabIndex = 11;
            this.box_CodeReq.Text = "Required";
            this.box_CodeReq.SelectedIndexChanged += new System.EventHandler(this.box_CodeReq_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chk_PopulateForm);
            this.groupBox7.Controls.Add(this.chk_PopulateViews);
            this.groupBox7.Location = new System.Drawing.Point(886, 273);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(288, 171);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Additional Options";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.num_PrimaryLength);
            this.groupBox8.Controls.Add(this.box_PrimaryReq);
            this.groupBox8.Controls.Add(this.txt_PrimaryCol);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Location = new System.Drawing.Point(592, 45);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(582, 92);
            this.groupBox8.TabIndex = 31;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Primary Column Properties";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(290, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 20);
            this.label15.TabIndex = 14;
            this.label15.Text = "Max Length *";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(428, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 20);
            this.label14.TabIndex = 6;
            this.label14.Text = "Requirement *";
            // 
            // num_PrimaryLength
            // 
            this.num_PrimaryLength.Location = new System.Drawing.Point(294, 52);
            this.num_PrimaryLength.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.num_PrimaryLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_PrimaryLength.Name = "num_PrimaryLength";
            this.num_PrimaryLength.Size = new System.Drawing.Size(132, 26);
            this.num_PrimaryLength.TabIndex = 5;
            this.num_PrimaryLength.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.num_PrimaryLength.ValueChanged += new System.EventHandler(this.num_PrimaryLength_ValueChanged);
            // 
            // box_PrimaryReq
            // 
            this.box_PrimaryReq.FormattingEnabled = true;
            this.box_PrimaryReq.Items.AddRange(new object[] {
            "Optional",
            "Required",
            "Recommended"});
            this.box_PrimaryReq.Location = new System.Drawing.Point(432, 51);
            this.box_PrimaryReq.Name = "box_PrimaryReq";
            this.box_PrimaryReq.Size = new System.Drawing.Size(144, 28);
            this.box_PrimaryReq.TabIndex = 6;
            this.box_PrimaryReq.Text = "Required";
            this.box_PrimaryReq.SelectedIndexChanged += new System.EventHandler(this.box_PrimaryReq_SelectedIndexChanged);
            // 
            // txt_PrimaryCol
            // 
            this.txt_PrimaryCol.Location = new System.Drawing.Point(6, 52);
            this.txt_PrimaryCol.MaxLength = 30;
            this.txt_PrimaryCol.Name = "txt_PrimaryCol";
            this.txt_PrimaryCol.Size = new System.Drawing.Size(282, 26);
            this.txt_PrimaryCol.TabIndex = 4;
            this.txt_PrimaryCol.Text = "Name";
            this.txt_PrimaryCol.TextChanged += new System.EventHandler(this.txt_PrimaryCol_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Label *";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lbl_DescReq);
            this.groupBox9.Controls.Add(this.num_DescLength);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.box_DescReq);
            this.groupBox9.Controls.Add(this.lbl_DescDataType);
            this.groupBox9.Controls.Add(this.box_CodeReq);
            this.groupBox9.Controls.Add(this.num_CodeLength);
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.lbl_DescDataLength);
            this.groupBox9.Controls.Add(this.box_DescDataType);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.box_CodeDataType);
            this.groupBox9.Controls.Add(this.txt_Desc);
            this.groupBox9.Controls.Add(this.txt_Code);
            this.groupBox9.Location = new System.Drawing.Point(4, 273);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(876, 171);
            this.groupBox9.TabIndex = 33;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Additional Column Properties";
            // 
            // CodeTableGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btn_Publish);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tree_Preview);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CodeTableGeneratorControl";
            this.Size = new System.Drawing.Size(1190, 761);
            this.Load += new System.EventHandler(this.CodeTableGeneratorControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_DescLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CodeLength)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_PrimaryLength)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TextBox txt_TableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Desc;
        private System.Windows.Forms.Label lbl_DescDataType;
        private System.Windows.Forms.ComboBox box_DescDataType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox box_CodeDataType;
        private System.Windows.Forms.Label lbl_DescDataLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown num_DescLength;
        private System.Windows.Forms.NumericUpDown num_CodeLength;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView tree_Preview;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_TableDesc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox box_Solution;
        private System.Windows.Forms.Button btn_Publish;
        private System.Windows.Forms.CheckBox chk_PopulateForm;
        private System.Windows.Forms.CheckBox chk_PopulateViews;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txt_PrimaryCol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_DescReq;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox box_DescReq;
        private System.Windows.Forms.ComboBox box_CodeReq;
        private System.Windows.Forms.NumericUpDown num_PrimaryLength;
        private System.Windows.Forms.ComboBox box_PrimaryReq;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox lst_Format;
        private System.Windows.Forms.GroupBox groupBox9;
    }
}
