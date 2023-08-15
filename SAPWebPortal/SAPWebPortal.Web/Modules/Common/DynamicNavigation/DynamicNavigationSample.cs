
using Microsoft.AspNetCore.Http;
using SAPWebPortal.Common.PermissionsKeys;
using SAPWebPortal.Default;
using Serenity;
using Serenity.Data;
using Serenity.Navigation;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Encodings.Web;
using System.Web;

namespace SAPWebPortal.Commen
{
    //public class DynamicNavigationSample : INavigationItemSource
    //{
    //    //public System.Collections.Generic.List<NavigationItemAttribute> GetItems()
    //    //{
    //    ////TwoLevelCache.ExpireGroupItems(Entities.UserPermissionRow.Fields.GenerationKey);
    //    ////TwoLevelCache.Remove("LeftNavigationModel:NavigationItems");
    //    //    var items = new System.Collections.Generic.List<NavigationItemAttribute>
    //    //    {
    //    //        new NavigationMenuAttribute(9500, "DataBase-Wise Reports", "fa fa-files-o")           
    //    //       // new NavigationMenuAttribute(9000, "Reports/Database", "fa fa-database")
    //    //    };
    //    //    // Add product categories as dynamic navigation items for demo purpose
    //    //    using (var connection = new SqlConnection(Startup.connectionString))
    //    //    {
    //    //        var Databases = connection.List<SapDatabasesRow>().ToList().Select(x => x.CompanyDb);
    //    //        foreach (var database in Databases)
    //    //        {
    //    //            var categories = connection.List<Report_UsersRow>(new Criteria(string.Format("DB_Name = '{0}'", database)));
    //    //            foreach (var category in categories)
    //    //            {
    //    //                var DB_Name = connection.List<ReportsRow>().FirstOrDefault(x => x.DB_Name == database.ToString()).DB_Name;
    //    //                var DbName = connection.List <SapDatabasesRow>().FirstOrDefault(x => x.CompanyDb == DB_Name).CompanyDb;
    //    //                var rDOC = connection.List<ReportsRow>().FirstOrDefault(x => x.Rdocid == category.Rodcid);
    //    //                items.Add(new NavigationLinkAttribute(9500,
    //    //                    path: "DataBase-Wise Reports/" + DbName + "/" + rDOC.RptName,
    //    //                    url: "~/Default/ReportPage?id=" + UrlEncoder.Default.Encode(rDOC.Rdocid.ToString()),
    //    //                    permission: MasterDataPermissionKeys.General,
    //    //                    icon: "fa-file-o"));
    //    //            }
    //    //        }
    //    //    }           
    //    //    return items;
    //    //}       
    //}
}