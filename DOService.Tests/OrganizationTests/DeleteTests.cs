using DOService.Controllers;
using DOService.Models;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DOService.Tests.OrganizationTests.DeleteTests
{
    [TestClass]
    public class DeleteTests
    {
        [TestMethod]
        public void DeleteOrganization_ShouldUpdateAnOrganization()
        {
            using (var orgContext = new OrganizationContext("DeleteTests"))
            {
                var context = orgContext.DbContext;

                orgContext.SeedDatabase();

                var controller = new OrganizationController(null, context);

                var org = context.Organizations.First();

                var action = controller.DeleteOrganization(org.Id) as OkObjectResult;

                Assert.IsNotNull(action);
                Assert.IsNull(action.Value);

                var nullOrg = context.Organizations.Find(org.Id);

                Assert.IsNull(nullOrg);
            }
        }
    }
}
