using SAPWebPortal;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.TestBase;

namespace TestProject
{
    public class TestBaseHelpers
    {
        protected Serenity.Data.WrappedConnection connection;

        public IRequestContext Context_Test { get { return new TestContext_Testing("admin"); } }

        public TestBaseHelpers()
        {  
            //     ((dynamic)controller).Context_Test = Context_Test;
            Program.IsTest = true;
            connection = new Serenity.Data.WrappedConnection(new System.Data.SqlClient.SqlConnection(Startup.connectionString), new SqlServer2012Dialect()); 
            // SAPDBNameHandler.AddDBName("admin", "SBODEMOAU");
            //Program.Main(new string[] { "%LAUNCHER_ARGS%" });
        }
         
    }
}