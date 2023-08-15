using System;

namespace SAPWebPortal
{
    internal class ServiceLayerAttribute : Attribute
    {
        internal string ModuleName { get; set; }
        internal string ObjType { private set; get; }
        internal string TableName {private get; set; }
        internal ServiceLayerAttribute(string ModuleName)
        {
            this.ModuleName = ModuleName;
            switch (ModuleName)
            {
                case "BusinessPartners":
                    ObjType = "2";
                    TableName = "OCRD";
                    break;
                case "Items":
                    ObjType = "4";
                    TableName = "OITM";
                    break;
                case "Users":
                    ObjType = "12";
                    TableName = "OUSR";
                    break;
                default:
                    break;
            }
        }
    }
}