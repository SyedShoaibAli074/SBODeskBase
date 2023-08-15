using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABIT_SAP_SmartApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperWebSL;
using System.Diagnostics;

namespace ABIT_SAP_SmartApp.Helpers.Tests
{
    [TestClass()]
    public class serenityHelperTests
    {
        HelperWebSL.serenityHelper serenityHelper;
        [TestInitialize]
        public void init()
        {
            serenityHelper = new HelperWebSL.serenityHelper();
        }
        [TestMethod()]
        public void _LoginTest()
        {
            var t = serenityHelper._Login("imran", "1234", "1", "SBDEMOAU");
            Assert.IsTrue(t); 
        }
    }
}