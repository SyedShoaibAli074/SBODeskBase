using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serenity.CodeGenerator;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serenity.CodeGenerator.Tests
{
    [TestClass()]
    public class SBOGenerateCommandTests
    {
        [TestMethod()]
        public void RunTest()
        {
            var prjpath = @"D:\Code\ABiT\ABiT_SAP_WebPortal\SAPWebPortal\SAPWebPortal.Web\SAPWebPortal.Web.csproj";
            string[] args = new string[] { "sbo" };
            var fs = new FileSystem();
            //SBOGenerateCommand.Run(prjpath, args, fs);
        }
         
    }
}