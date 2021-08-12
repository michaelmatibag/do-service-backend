using DOService.Controllers;
using DOService.Features.DoiOwnerRepository;
using DOService.Tests.FakeDbContexts.DoiOwnerContext;
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
            using (var context = new DoiOwnerContext("DeleteTests.DeleteDoiOwner"))
            {
                context.SeedDatabase();

                var owner = context.ServiceContext.DoiOwners.First();

                var action = new DoiOwnerController(null, new DoiOwnerRepository(context.ServiceContext)).DeleteDoiOwner(owner.Id) as OkResult;

                Assert.IsNotNull(action);
                Assert.AreEqual(action.StatusCode, 200);
                Assert.IsNull(context.ServiceContext.DoiOwners.Find(owner.Id));
            }
        }
    }
}
