using DOService.Controllers;
using DOService.Models;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DOService.Tests.OrganizationTests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void AddOrganization_ShouldAddAnOrganization()
        {
            using (var orgContext = new OrganizationContext("PostTests.AddOrganization"))
            {
                var repository = orgContext.Repository;

                orgContext.SeedDatabase();

                var controller = new OrganizationController(null, repository);

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
