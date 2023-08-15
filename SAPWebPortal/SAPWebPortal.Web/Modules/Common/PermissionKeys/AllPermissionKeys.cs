

using Serenity.ComponentModel;
using System.ComponentModel;

namespace SAPWebPortal.Common.PermissionsKeys
{
    [NestedPermissionKeys]
    [DisplayName("MasterData")]
    public class MasterDataPermissionKeys
    {
        public const string General = "MasterData:General";

        [DisplayName("BusinessPartners")]
        public class BusinessPartners
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "MasterData:BusinessPartners:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "MasterData:BusinessPartners:Modify";
            public const string View = "MasterData:BusinessPartners:View";
            public const string Insert = "MasterData:BusinessPartners:Insert";
        }

        [DisplayName("Items")]
        public class Items
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "MasterData:Items:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "MasterData:Items:Modify";
            public const string View = "MasterData:Items:View";
            public const string Insert = "MasterData:Items:Insert";
        }

        [DisplayName("RecordCounts")]
        public class RecordCounts
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "MasterData:RecordCounts:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "MasterData:RecordCounts:Modify";
            public const string View = "MasterData:RecordCounts:View";
            public const string Insert = "MasterData:RecordCounts:Insert";
        }


    }

    [NestedPermissionKeys]
    [DisplayName("MarketingDocs")]
    public class MarketingDocsPermissionKeys
    {
        public const string General = "MarketingDocs:General";

        [DisplayName("SalesOrder")]
        public class SalesOrder
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "MarketingDocs:SalesOrder:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "MarketingDocs:SalesOrder:Modify";
            public const string View = "MarketingDocs:SalesOrder:View";
            public const string Insert = "MarketingDocs:SalesOrder:Insert";
        }
        [DisplayName("SalesOrderLines")]
        public class SalesOrderLines
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "MarketingDocs:SalesOrderLines:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "MarketingDocs:SalesOrderLines:Modify";
            public const string View = "MarketingDocs:SalesOrderLines:View";
            public const string Insert = "MarketingDocs:SalesOrderLines:Insert";
        }

        [DisplayName("Delivery")]
        public class Delivery
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "MarketingDocs:Delivery:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "MarketingDocs:Delivery:Modify";
            public const string View = "MarketingDocs:Delivery:View";
            public const string Insert = "MarketingDocs:Delivery:Insert";
        } 
        [DisplayName("SalesQuotations")]
        public class SalesQuotations
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "MarketingDocs:SalesQuotations:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "MarketingDocs:SalesQuotations:Modify";
            public const string View = "MarketingDocs:SalesQuotations:View";
            public const string Insert = "MarketingDocs:SalesQuotations:Insert";
        }
    }
    [NestedPermissionKeys]
    [DisplayName("ApprovalProcess")]
    public class ApprovalProcessPermissionKeys
    {
       public const string General = "ApprovalProcess:General";

        [DisplayName("ApprovalRequests")]
        public class ApprovalRequests
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "ApprovalProcess:ApprovalRequests:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "ApprovalProcess:ApprovalRequests:Modify";
            public const string View = "ApprovalProcess:ApprovalRequests:View";
            public const string Insert = "ApprovalProcess:ApprovalRequests:Insert";
        }

        [DisplayName("Drafts Documents")]
        public class Drafts
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "ApprovalProcess:Drafts:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "ApprovalProcess:Drafts:Modify";
            public const string View = "ApprovalProcess:Drafts:View";
            public const string Insert = "ApprovalProcess:Drafts:Insert";
        }
        public const string DefaultGeneral = "Administration:DefaultGeneral";
    }
    [NestedPermissionKeys]
    [DisplayName("ReportsDocs")]
    public class ReportsPermissionKeys
    {
        public const string General = "Reports:General";

        [DisplayName("Reports")]
        public class Reports
        {
            [ImplicitPermission(General), ImplicitPermission(View)]
            public const string Delete = "ReportsDocs:Reports:Delete";
            [Description("Create/Update"), ImplicitPermission(General), ImplicitPermission(View)]
            public const string Modify = "ReportsDocs:Reports:Modify";
            public const string View = "ReportsDocs:Reports:View";
            public const string Insert = "ReportsDocs:Reports:Insert";
        }

    }

   
}
