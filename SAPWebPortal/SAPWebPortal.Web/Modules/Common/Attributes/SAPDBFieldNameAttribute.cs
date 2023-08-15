using System;

namespace SAPWebPortal
{
    public class SAPDBFieldNameAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public SAPDBFieldNameAttribute(string ColumnName)
        {
            this.ColumnName= ColumnName;
        }
    }
}