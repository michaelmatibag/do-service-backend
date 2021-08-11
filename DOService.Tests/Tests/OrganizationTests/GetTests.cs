using DOService.Controllers;
using DOService.Models;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOService.Features.OrganizationRepository;

namespace DOService.Tests.OrganizationTests
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void GetOrganizations_ShouldReturnAllOrganizations()
        {
            using (var context = new OrganizationContext("GetTests.GetOrganizations"))
            {
                context.SeedDatabase();

                var action = new OrganizationController(null, new OrganizationRepository(context.DbContext)).GetOrganizations().Result as OkObjectResult;

                Assert.AreEqual(3, (action.Value as IEnumerable<OrganizationResponse>).Count());
            }
        }

        [TestMethod]
        public void GetOrganization_ShouldReturnAnOrganization()
        {
            using (var context = new OrganizationContext("GetTests.GetOrganization"))
            {
                context.SeedDatabase();

                var organization = context.DbContext.Organizations.First();

                var action = new OrganizationController(null, new OrganizationRepository(context.DbContext)).GetOrganization(organization.Id).Result as OkObjectResult;
                
                var result = action.Value as OrganizationResponse;

                Assert.AreEqual(organization.Id, result.Id);
                Assert.AreEqual(organization.Name, result.Name);
            }
        }
    }
}
