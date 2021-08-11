using DOService.Controllers;
using DOService.Features.OrganizationRepository;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DOService.Tests.OrganizationTests
{
    [TestClass]
    public class DeleteTests
    {
        [TestMethod]
        public void DeleteOrganization_ShouldUpdateAnOrganization()
        {
            using (var context = new OrganizationContext("DeleteTests.DeleteOrganization"))
            {
                context.SeedDatabase();

                var organization = context.DbContext.Organizations.First();

                var action = new OrganizationController(null, new OrganizationRepository(context.DbContext)).DeleteOrganization(organization.Id) as OkResult;

                Assert.IsNotNull(action);
                Assert.AreEqual(action.StatusCode, 200);
                Assert.IsNull(context.DbContext.Organizations.Find(organization.Id));
            }
        }
    }
}
