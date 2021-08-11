using DOService.Controllers;
using DOService.Features.OrganizationRepository;
using DOService.Models;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DOService.Tests.OrganizationTests
{
    [TestClass]
    public class PutTests
    {
        [TestMethod]
        public void UpdateOrganization_ShouldUpdateAnOrganization()
        {
            using (var context = new OrganizationContext("PutTests.UpdateOrganization"))
            {

                context.SeedDatabase();

                var organization = context.ServiceContext.Organizations.First();

                var organizationRequest = new OrganizationRequest { Name = "Update Test" };

                var action = new OrganizationController(null, new OrganizationRepository(context.ServiceContext)).UpdateOrganization(organization.Id, organizationRequest).Result as OkObjectResult;
                
                var result = action.Value as OrganizationResponse;

                Assert.AreEqual(organization.Id, result.Id);
                Assert.AreEqual(organization.Name, result.Name);
            }
        }
    }
}
