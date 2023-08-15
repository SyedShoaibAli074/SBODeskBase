using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelperWebSL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HelperWebSL.Controllers.Tests
{
    [TestClass()]
    public class BanksHelperTests
    {
        [TestMethod()]
        public void RefreshTest()
        {
            BanksHelper helper = new BanksHelper();
            helper.Refresh();
            Debug.WriteLine(helper.ListofBanks.ToString());
            Assert.IsTrue(helper.ListofBanks.Count > 0); 
        }
    }
}