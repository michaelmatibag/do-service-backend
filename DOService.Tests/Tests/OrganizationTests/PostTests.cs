using DOService.Controllers;
using DOService.Features.OrganizationRepository;
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
            using (var context = new OrganizationContext("PostTests.AddOrganization"))
            {
                context.SeedDatabase();

                var organizationRequest = new OrganizationRequest { Name = "Test Org 4" };

                var action = new OrganizationController(null, new OrganizationRepository(context.ServiceContext)).AddOrganization(organizationRequest).Result as OkObjectResult;
                
                var result = action.Value as OrganizationResponse;

                Assert.AreEqual(organizationRequest.Name, result.Name);
            }
        }
    }
}
