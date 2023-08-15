using System;

namespace SAPWebPortal.Web.Models.SLModels
{
    public class UDFs
    {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class UserTable
        {
            public string TableDescription { get; set; }
            public string TableName { get; set; }
            public string TableType { get; set; }
        }
        public class UserTableResponse
        {

            public string TableName { get; set; }
            public bool? Created { get; set; }
            public string Reason { get; set; }

        }

        public class UserField
        {
            public string Description { get; set; }
            public string Name { get; set; }
            public string SubType { get; set; }
            public string TableName { get; set; }
            public string Type { get; set; }
            public Int32? Size { get; set; }
        }
        public class UserFieldResponse
        {

            public string Name { get; set; }

            public string TableName { get; set; }
            public bool? Created { get; set; }
            public string Reason { get; set; }

        }

        public class UserObjectMDChildTable
        {
            public int SonNumber { get; set; }
            public string TableName { get; set; }
            public string LogTableName { get; set; }
            public string Code { get; set; }
            public string ObjectName { get; set; }
        }

        public class UserObjectMDFindColumn
        {
            public int ColumnNumber { get; set; }
            public string ColumnAlias { get; set; }
            public string ColumnDescription { get; set; }
            public string Code { get; set; }
        }

        public class UserObjectMDFormColumn
        {
            public string FormColumnAlias { get; set; }
            public string FormColumnDescription { get; set; }
            public int FormColumnNumber { get; set; }
            public int SonNumber { get; set; }
            public string Code { get; set; }
            public string Editable { get; set; }
        }

        public class UserObjectMDEnhancedFormColumn
        {
            public string Code { get; set; }
            public int ColumnNumber { get; set; }
            public int ChildNumber { get; set; }
            public string ColumnAlias { get; set; }
            public string ColumnDescription { get; set; }
            public string ColumnIsUsed { get; set; }
            public string Editable { get; set; }
        }

        public class UserObject
        { 
            public string TableName { get; set; }
            public string Code { get; set; }
            public string LogTableName { get; set; }
            public string CanCreateDefaultForm { get; set; }
            public string ObjectType { get; set; }
            public object ExtensionName { get; set; }
            public string CanCancel { get; set; }
            public string CanDelete { get; set; }
            public string CanLog { get; set; }
            public string ManageSeries { get; set; }
            public string CanFind { get; set; }
            public string CanYearTransfer { get; set; }
            public string Name { get; set; }
            public string CanClose { get; set; }
            public string OverwriteDllfile { get; set; }
            public string UseUniqueFormType { get; set; }
            public string CanArchive { get; set; }
            public string MenuItem { get; set; }
            public string MenuCaption { get; set; }
            public object FatherMenuID { get; set; }
            public object Position { get; set; }
            public object MenuUID { get; set; }
            public string EnableEnhancedForm { get; set; }
            public string RebuildEnhancedForm { get; set; }
            public string FormSRF { get; set; }
            public System.Collections.Generic. List<UserObjectMDChildTable> UserObjectMD_ChildTables { get; set; }
            public System.Collections.Generic.List<UserObjectMDFindColumn> UserObjectMD_FindColumns { get; set; }
            public System.Collections.Generic.List<UserObjectMDFormColumn> UserObjectMD_FormColumns { get; set; }
            public System.Collections.Generic.List<UserObjectMDEnhancedFormColumn> UserObjectMD_EnhancedFormColumns { get; set; }
        }
        public class UserObjectResponse
        {
            public string Code { get; set; }
            public bool? Created { get; set; }
            public string Reason { get; set; }


        }

        public class UdfsRequest
        {
            public System.Collections.Generic.List<UserTable> UserTables { get; set; }
            public System.Collections.Generic.List<UserField> UserFields { get; set; }
            public System.Collections.Generic.List<UserObject> UserObjects { get; set; }
        }
        public class UdfsResponse
        {
            public System.Collections.Generic.List<UserTableResponse> UserTables { get; set; }
            public System.Collections.Generic.List<UserFieldResponse> UserFields { get; set; }
            public System.Collections.Generic.List<UserObjectResponse> UserObjects { get; set; }
        }
    }
}
