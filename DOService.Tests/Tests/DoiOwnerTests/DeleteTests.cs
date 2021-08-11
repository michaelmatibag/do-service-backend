using DOService.Controllers;
using DOService.Features.OrganizationRepository;
using DOService.Tests.FakeDbContexts.OrganizationContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DOService.Tests.DoiOwnerTests
{
    [TestClass]
    public class DeleteTests
    {
        [TestMethod]
        public void DeleteOrganization_ShouldUpdateAnOrganization()
        {
            using (var context = new OrganizationContext("DeleteTests.DeleteDoiOwner"))
            {
                context.SeedDatabase();

                var organization = context.ServiceContext.Organizations.First();

                var action = new OrganizationController(null, new OrganizationRepository(context.ServiceContext)).DeleteOrganization(organization.Id) as OkResult;

                Assert.IsNotNull(action);
                Assert.AreEqual(action.StatusCode, 200);
                Assert.IsNull(context.ServiceContext.Organizations.Find(organization.Id));
            }
        }
    }
}
