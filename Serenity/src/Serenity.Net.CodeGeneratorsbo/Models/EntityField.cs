namespace Serenity.CodeGenerator
{
    public class EntityField
    { private string _FieldType;
        public string FieldType
        {
            get {
                return _FieldType; 
            }
            set
            { 
                _FieldType = value.Replace("System.", "").Replace("[", "").Replace("]", "").Replace("Nullable`1", "")
                    .Replace("SAPB1.BoYesNoEnum", "String").Replace("SAPB1.InvBaseDocTypeEnum", "String").Replace("SAPB1.BoStatus", "String")
                    //Collections.ObjectModel.Collection`1SAPB1.X
                    //replace with List<X>
                    .Replace("Collections.ObjectModel.Collection`1.SAPB1.", "List<")
                    ;
                //if _FieldTypeContains "List<" then end it by ">"
                if (_FieldType.Contains("List<"))
                {
                    _FieldType = _FieldType + ">";
                }
            }
        }
        private string _DataType;
        public string DataType
        {
            get
            {
                //todo: datatype controll is here
                return _DataType.Replace("System.", "").Replace("[", "").Replace("]", "").Replace("Nullable`1", "")
                    .Replace("SAPB1.BoYesNoEnum", "String").Replace("SAPB1.InvBaseDocTypeEnum", "String").Replace("SAPB1.BoStatus", "String")
                    //Collections.ObjectModel.Collection`1SAPB1.X
                    //replace with List<X>
                    .Replace("Collections.ObjectModel.Collection`1.SAPB1.", "List<")
                    ;
            }
            set
            {
                _DataType = value.Replace("System.", "").Replace("[", "").Replace("]", "").Replace("Nullable`1", "")
                    .Replace("SAPB1.BoYesNoEnum", "String").Replace("SAPB1.InvBaseDocTypeEnum", "String").Replace("SAPB1.BoStatus", "String")
                    //Collections.ObjectModel.Collection`1SAPB1.X
                    //replace with List<X>
                    .Replace("Collections.ObjectModel.Collection`1.SAPB1.", "List<")
                    ; ;
            }
        }
 string _TSType;
        public string TSType
        {
            get
            {
                return _TSType;
            }
            set
            {
                _TSType = value;
            }
        }
        public string Ident { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Flags { get; set; }
        public string PKSchema { get; set; }
        public string PKTable { get; set; }
        public string PKColumn { get; set; }
        public string ForeignJoinAlias { get; set; }
        public bool Insertable { get; set; }
        public bool Updatable { get; set; }
        public bool IsValueType { get; set; }
        public int? Size { get; set; }
        public int Scale { get; set; }
        public string TextualField { get; set; }
        public string Attributes { get; set; }
        public string ColAttributes { get; set; }
        public string Expression { get; set; }

        public string TSEditorType
        {
            get
            {
                return FieldType switch
                {
                    "Int32" or "Int16" or "Int64" => "IntegerEditor",
                    "Single" or "Double" or "Decimal" => "DecimalEditor",
                    "DateTime" => "DateEditor",
                    "Boolean" => "BooleanEditor",
                    _ => "StringEditor",
                };
            }
        }

        public string PropertyType
        {
            get { return IsValueType ? DataType + "?" : DataType; }
        }
    }
}