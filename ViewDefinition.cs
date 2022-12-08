using Microsoft.Xrm.Sdk;
using System;

namespace CodeTableGenerator
{
    internal class ViewDefinition
    {
        private readonly Entity record;

        public ViewDefinition(Entity viewEntity)
        {
            record = viewEntity;
        }

        public string FetchXml
        {
            get
            {
                return record.GetAttributeValue<string>("fetchxml");
            }
            set
            {
                record["fetchxml"] = value;
            }
        }

        public Guid Id => record.Id;

        public Entity InnerRecord => record;

        public string LayoutXml
        {
            get
            {
                return record.GetAttributeValue<string>("layoutxml");
            }
            set { record["layoutxml"] = value; }
        }

        public string LogicalName => record.LogicalName;

        public string Name => record.GetAttributeValue<string>("name");

        public int Type => record.GetAttributeValue<int>("querytype");
    }
}