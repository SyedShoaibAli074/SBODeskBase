using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Administration.Entities;
using SAPWebPortal.Default.Endpoints;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.TestBase;

namespace SAPWebPortal.Administration.Endpoints.Tests
{
    [TestClass()]
    public class UserControllerTests : TestBase<UserController, SAPWebPortal.Administration.Entities.UserRow>
    {
        [TestMethod()]
        public void SetActiveCompanyTest()
        {
            var company = "SBODEMOAU";
            controller.SetActiveCompany(this.connection, new { CompanyDB =  company});
            var activecompany = controller.ActiveCompany();
            Assert.IsTrue(activecompany .CompanyDB== company);
        }
        [TestMethod]
        public void GetActiveCompanyTest()
        {
           var companydb =  controller.ActiveCompany();
            Debug.WriteLine(companydb);
            Assert.IsTrue(companydb.CompanyDB.Length > 0);
        }
        [TestMethod]
        public void CreateUserTest()
        { 
            Request.Entity = new UserRow();
            Request.Entity.Username = "testone";
            Request.Entity.Password = "testone";
            Request.Entity.Email = "mimran@abitcons.com";
            //Select * users where Source = 'SBO'
            var query = "select * from Users where Source = 'SBO'";
            
           var created =  controller.Create(uow,Request);
            
            

        }

    }
}