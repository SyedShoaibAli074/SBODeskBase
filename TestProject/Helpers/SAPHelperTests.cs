using HelperWebSL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPWebPortal.Default;
using SAPWebPortal.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace SAPWebPortal.Web.Helpers.Tests
{
    [TestClass()]
    public class SAPHelperTests 
    {
     
        [TestMethod()]
        public void ConvertFieldNameSL2DBTest()
        {
         var fieldname =    SAPHelper<BusinessPartnerRow>.ConvertFieldNameSL2DB("CardCode");
            Assert.AreEqual("CardCode", fieldname);
        }
    

    }
}