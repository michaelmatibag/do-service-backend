using DOService.Controllers;
using DOService.Models;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DOService.Tests.DoiOwnerTests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void AddOrganization_ShouldAddAnOrganization()
        {
            using (var orgContext = new OrganizationContext("DoiOwner.PostTests"))
            {
                var repostory = orgContext.Repository;

                orgContext.SeedDatabase();

                var controller = new OrganizationController(null, repostory);

                var newOrg = new OrganizationRequest
                {
                    Name = "Test Org 4"
                };

                var action = controller.AddOrganization(newOrg).Result as OkObjectResult;
                var result = action.Value as OrganizationResponse;

                Assert.AreEqual(newOrg.Name, result.Name);
            }
        }
    }
}
