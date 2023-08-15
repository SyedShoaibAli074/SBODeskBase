using Serenity.Navigation;
using MyPages = SAPWebPortal.Administration.Pages;
using Administration = SAPWebPortal.Administration.Pages;

[assembly: NavigationMenu(9000, "Administration", icon: "fa-wrench")]
//[assembly: NavigationLink(9100, "Administration/Languages", typeof(Administration.LanguageController), icon: "fa-comments")]
//[assembly: NavigationLink(9200, "Administration/Translations", typeof(Administration.TranslationController), icon: "fa-comment-o")]
[assembly: NavigationLink(9300, "Administration/Roles", typeof(Administration.RoleController), icon: "fa-lock")]
[assembly: NavigationLink(9400, "Administration/User Management", typeof(Administration.UserController), icon: "fa-users")]
//[assembly: NavigationLink(int.MaxValue, "Administration/Sessions", typeof(MyPages.SessionsController), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Administration/Exceptions", typeof(MyPages.ExceptionsController), icon: "fa fa-exclamation-triangle")]
/*[assembly: NavigationLink(int.MaxValue, "Administration/Log", typeof(MyPages.LogController), icon: "fa-book")]*/
//[assembly: NavigationLink(int.MaxValue, "Administration/Settings", typeof(MyPages.SettingsController), icon: "fa fa-cogs")]
//[assembly: NavigationLink(int.MaxValue, "Administration/User Form Authorizations", typeof(MyPages.UserFormAuthorizationsController), icon: "fa-users")]
//[assembly: NavigationLink(int.MaxValue, "Administration/User Form Authorizations Details", typeof(MyPages.UserFormAuthorizationsDetailsController), icon: null)]