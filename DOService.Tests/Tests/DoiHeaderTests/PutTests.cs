using DOService.Controllers;
using DOService.Models;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DOService.Tests.DoiHeaderTests
{
    [TestClass]
    public class PutTests
    {
        [TestMethod]
        public void UpdateOrganization_ShouldUpdateAnOrganization()
        {
            using (var orgContext = new OrganizationContext("DoiHeader.PutTests"))
            {
                var context = orgContext.DbContext;

                orgContext.SeedDatabase();

                var controller = new OrganizationController(null, context);

                var org = context.Organizations.First();

                var changeSet = new OrganizationRequest
                {
                    Name = "Update Test"
                };

                Assert.AreNotEqual(org.Name, changeSet.Name);

                var action = controller.UpdateOrganization(org.Id, changeSet).Result as OkObjectResult;
                var result = action.Value as OrganizationResponse;

                Assert.AreEqual(org.Id, result.Id);
                Assert.AreEqual(org.Name, result.Name);
            }
        }
    }
}
