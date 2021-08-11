using DOService.Controllers;
using DOService.Models;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DOService.Tests.OrganizationTests.PostTests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void AddOrganziation_ShouldAddAnOrganization()
        {
            var OrgContext = new OrganizationContext();

            using (var context = OrgContext.DbContext)
            {
                var controller = new OrganizationController(null, context);

                var newOrg = new OrganziationRequest
                {
                    Name = "Test Org 4"
                };

                var action = controller.AddOrganziation(newOrg).Result as OkObjectResult;
                var result = action.Value as OrganziationResponse;

                Assert.AreEqual(newOrg.Name, result.Name);
            }
        }
    }
}
