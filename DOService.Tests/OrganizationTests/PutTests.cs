using DOService.Controllers;
using DOService.Models;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DOService.Tests.OrganizationTests.PutTests
{
    [TestClass]
    public class PutTests
    {
        [TestMethod]
        public void UpdateOrganziation_ShouldUpdateAnOrganization()
        {
            var OrgContext = new OrganizationContext();

            using (var context = OrgContext.DbContext)
            {
                OrgContext.SeedDatabase();

                var controller = new OrganizationController(null, context);

                var org = context.Organizations.First();

                var changeSet = new OrganziationRequest
                {
                    Name = "Update Test"
                };

                Assert.AreNotEqual(org.Name, changeSet.Name);

                var action = controller.UpdateOrganziation(org.Id, changeSet).Result as OkObjectResult;
                var result = action.Value as OrganziationResponse;

                Assert.AreEqual(org.Id, result.Id);
                Assert.AreEqual(org.Name, result.Name);
            }
        }
    }
}
