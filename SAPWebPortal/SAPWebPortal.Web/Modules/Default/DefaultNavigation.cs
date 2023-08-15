﻿using Serenity.Navigation;
using MyPages = SAPWebPortal.Default.Pages;
//[assembly: NavigationLink(int.MaxValue, "Administration/Record Counts", typeof(MyPages.RecordCountsController), icon: "fa fa-sort-numeric-asc")]
[assembly: NavigationLink(int.MaxValue, "Administration/Sap Databases", typeof(MyPages.SapDatabasesController), icon: "fa fa-database")]

[assembly: NavigationMenu(int.MaxValue, "Master Data", icon: "fa fa-folder")]
[assembly: NavigationLink(int.MaxValue, "Master Data/Business Partner", typeof(MyPages.BusinessPartnerController), icon: "fa fa-handshake-o")] 
[assembly: NavigationLink(int.MaxValue, "Master Data/Item Master", typeof(MyPages.ItemController), icon: "fa fa-list-alt")]
[assembly: NavigationLink(int.MaxValue, "Administration/Shopify Settings", typeof(MyPages.ShopifySettingsController), icon: "fa fa-list-alt")]
//[assembly: NavigationLink(int.MaxValue, "Default/Shopify Settings Detail", typeof(MyPages.ShopifySettingsDetailController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Administration/Shopify Sub Settings", typeof(MyPages.ShopifySubSettingsController), icon: "fa fa-list-alt")]
//[assembly: NavigationLink(int.MaxValue, "Default/Bp Addresses", typeof(MyPages.BPAddressesController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Contact Employees", typeof(MyPages.ContactEmployeesController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Bp Payment Methods", typeof(MyPages.BPPaymentMethodsController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Item Warehouse Info Collection", typeof(MyPages.ItemWarehouseInfoCollectionController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Business Partner Group", typeof(MyPages.BusinessPartnerGroupController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Warehouse", typeof(MyPages.WarehouseController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Additional Expense", typeof(MyPages.AdditionalExpenseController), icon: null)]
//[assembly: NavigationMenu(int.MaxValue, "Approval Process", icon: "fa fa-external-link")]
//[assembly: NavigationMenu(int.MaxValue, "Payment", icon: "fa fa-external-link")]
//[assembly: NavigationLink(int.MaxValue, "Approval Process/Approval Requests", typeof(MyPages.ApprovalRequestController), icon: "fa fa-exchange")]
//[assembly: NavigationLink(int.MaxValue, "Default/Approval Request Line", typeof(MyPages.ApprovalRequestLineController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Approval Request Decision", typeof(MyPages.ApprovalRequestDecisionController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Chart Of Account", typeof(MyPages.ChartOfAccountController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Report Users", typeof(MyPages.Report_UsersController), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/User Detail1", typeof(MyPages.UserDetail1Controller), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/User Detail2", typeof(MyPages.UserDetail2Controller), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Default/Ipbatch1", typeof(MyPages.Ipbatch1Controller), icon: null)]
//[assembly: NavigationLink(int.MaxValue, "Payment/Incoming Payment Batch", typeof(MyPages.OipbatchController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Administration/Log", typeof(MyPages.LogController), icon: "fa-book")]
[assembly: NavigationLink(int.MaxValue, "Administration/Shopify Webkook Settings", typeof(MyPages.ShopifyWebkookSettingsController), icon: "fa fa-list-alt")]
//[assembly: NavigationLink(int.MaxValue, "Default/Shopify Location Detail", typeof(MyPages.ShopifyLocationDetailController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Administration/Sap To Shopify Sync Log", typeof(MyPages.SapToShopifySyncLogController), icon: "fa fa-list-alt")]