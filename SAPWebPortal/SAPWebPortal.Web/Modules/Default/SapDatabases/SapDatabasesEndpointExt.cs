using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.ComponentModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using MyRow = SAPWebPortal.Default.SapDatabasesRow;
using Serenity.Web;

namespace SAPWebPortal.Default.Endpoints
{
    [LookupScript]
    public sealed class SapDatabasesEndpointExt : RowLookupScript<SapDatabasesRow>
    {
        public SapDatabasesEndpointExt(ISqlConnections sqlConnections)
            : base(sqlConnections)
        {
            IdField = SapDatabasesRow.Fields.IdField.Name;
            Permission = "*";
        }

        protected override void PrepareQuery(SqlQuery query)
        {
            base.PrepareQuery(query);

            query.Select(SapDatabasesRow.Fields.IdField.Name);
        }
    }
}