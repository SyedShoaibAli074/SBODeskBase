using Microsoft.VisualStudio.TestTools.UnitTesting;
using elpersWebSL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperWebSL.Controllers;

namespace elpersWebSL.Controllers.Tests
{
    [TestClass()]
    public class CustomerHelperTests
    {
        [TestMethod()]
        public void RefreshTest()
        {
            CustomerHelper helper = new CustomerHelper();
            helper.Refresh();
            Assert.IsTrue(helper.ListofCustomers.Count > 0);
        }
    }
}