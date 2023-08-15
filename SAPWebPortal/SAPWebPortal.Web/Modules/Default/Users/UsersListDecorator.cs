using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPWebPortal.Default
{
   
    public class UsersListDecorator : BaseCellDecorator
    {
        public override void Decorate()
        {
            var idList = this.Value as IEnumerable<int>;
            if (idList == null || !idList.Any())
            {
                this.Value = "";
                return;
            }

            //var byId = TwoLevelCache.GetLocalStoreOnly("UsersListDecorator:UsersById", 
            //    TimeSpan.Zero, ReportsRow.Fields.GenerationKey, () =>
            //    {
            //        using (var connection = SqlConnections.NewFor<RdocRow>())
            //        {
            //            var fld = RdocRow.Fields;
            //            return connection.List<RdocRow>(q => q
            //                .Select(fld.Rdocid)
            //                .Select(fld.RptName)
            //                .Select(fld.DB_Name))
            //                .ToDictionary(x => x.Rdocid.Value);
            //        }
            //    });

            //this.Value = String.Join(", ", idList.Select(x =>
            //{

            //    ReportsRow e;
            //    return byId.TryGetValue(x, out e) ? e.RptName : x.ToString();
            //}));
        }
    }
}