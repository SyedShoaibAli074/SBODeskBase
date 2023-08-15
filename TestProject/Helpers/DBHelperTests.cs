using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPWebPortal.Web.Modules.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWebPortal.Web.Modules.Common.Helpers.Tests
{
    [TestClass()]
    public class DBHelperTests
    {
        [TestMethod()]
        public void GetDBConnectionTest()
        {
            DBHelper.GetDBConnection("sap", "SBODemoAU", "sa", "P($$30r)", "sql");
        }
    }
}