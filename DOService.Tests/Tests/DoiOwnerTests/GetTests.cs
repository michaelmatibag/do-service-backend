using DOService.Controllers;
using DOService.Models;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DOService.Tests.DoiOwnerTests
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void GetOrganizations_ShouldReturnAllOrganizations()
        {
            using (var orgContext = new OrganizationContext("DoiOwner.GetTests"))
            {
                var repository = orgContext.Repository;

                orgContext.SeedDatabase();

                var controller = new OrganizationController(null, repository);

                var action = controller.GetOrganizations().Result as OkObjectResult;
                var result = (action.Value as IEnumerable<Organization>).ToList();

                Assert.AreEqual(3, result.Count);
            }
        }

        [TestMethod]
        public void GetOrganization_ShouldReturnAnOrganization()
        {
            using (var orgContext = new OrganizationContext("DoiOwner.GetTests"))
            {
                var repository = orgContext.Repository;
                var context = orgContext.DbContext;

                orgContext.SeedDatabase();

                var controller = new OrganizationController(null, repository);

                var org = context.Organizations.First();

                var action = controller.GetOrganization(org.Id).Result as OkObjectResult;
                var result = action.Value as OrganizationResponse;

                Assert.AreEqual(org.Id, result.Id);
                Assert.AreEqual(org.Name, result.Name);
            }
        }
    }
}
