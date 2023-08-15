using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPWebPortal.Administration;
using SAPWebPortal.Administration.Entities;
using SAPWebPortal.Membership.Pages;
using Serenity.Data;
using Serenity.Tests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestBase;

namespace SAPWebPortal.Membership.Pages.Tests
{
    [TestClass()]
    public class AccountControllerTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            var twolevelcashe = new NullTwoLevelCache();
            var textlocalizer = new TextLocalizer();
            Startup.RegisterDataProviders();
            var sqlConnections = new Serenity.Data.WrappedConnection(new System.Data.SqlClient.SqlConnection(Startup.connectionString), new SqlServer2012Dialect());
            DefaultSqlConnections connection = new DefaultSqlConnections(new ConnectionStrings());
            var retrieveservice = new UserRetrieveService(twolevelcashe, connection);
            AccountController controller = new AccountController(twolevelcashe, textlocalizer);
            var result = controller.Login(new LoginRequest() { CompanyDatabase = "1", Username = "imran", Password = "1234" }, null, retrieveservice);

            Debug.WriteLine(result.ToString());
        }

        [TestMethod()]
        public void SessionManagementTest()
        {
            var twolevelcashe = new NullTwoLevelCache();
            var textlocalizer = new TextLocalizer();
            Startup.RegisterDataProviders();

            AccountController controller = new AccountController(twolevelcashe, textlocalizer);
            controller.SessionManagement().Wait();
        }

        [TestMethod()]
        public void SessionManagementTest1()
        {
            var twolevelcashe = new NullTwoLevelCache();
            var textlocalizer = new TextLocalizer();
            Startup.RegisterDataProviders();

            AccountController controller = new AccountController(twolevelcashe, textlocalizer);
            controller.SessionManagement("imran","1234", "SBODEMOAU02").Wait();
        }
    }
    class ConnectionStrings : IConnectionStrings
    {
        public IEnumerable<IConnectionString> ListConnectionStrings()
        {
            yield return new ConnectionString();
        }

        public IConnectionString TryGetConnectionString(string connectionKey)
        {
            return new ConnectionString();
        }
    }
    class ConnectionString : IConnectionString
    {
        public ISqlDialect Dialect =>   new SqlServer2012Dialect();

        public string ConnectionKey => "Default";

        public string ProviderName => "System.Data.SqlClient";

        string IConnectionString.ConnectionString => Startup.connectionString;
    }

}