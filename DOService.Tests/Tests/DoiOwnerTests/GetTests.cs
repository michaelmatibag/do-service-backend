using DOService.Controllers;
using DOService.Models;
using DOService.Tests.FakeDbContexts.DoiOwnerContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DOService.Features.DoiOwnerRepository;

namespace DOService.Tests.DoiOwnerTests
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void GetOrganizations_ShouldReturnAllOrganizations()
        {
            using (var context = new DoiOwnerContext("GetTests.GetDoiOwners"))
            {
                context.SeedDatabase();

                var action = new DoiOwnerController(null, new DoiOwnerRepository(context.ServiceContext)).GetDoiOwners().Result as OkObjectResult;

                Assert.AreEqual(2, (action.Value as IEnumerable<DoiOwnerResponse>).Count());
            }
        }

        [TestMethod]
        public void GetOrganization_ShouldReturnAnOrganization()
        {
            using (var context = new DoiOwnerContext("GetTests.GetDoiOwner"))
            {
                context.SeedDatabase();

                var owner = context.ServiceContext.DoiOwners.First();

                var action = new DoiOwnerController(null, new DoiOwnerRepository(context.ServiceContext)).GetDoiOwner(owner.Id).Result as OkObjectResult;

                var result = action.Value as DoiOwnerResponse;

                Assert.AreEqual(owner.Id, result.Id);
                Assert.AreEqual(owner.OrganizationId, result.OrganizationId);
                Assert.AreEqual(owner.DoiHeaderId, result.DoiHeaderId);
                Assert.AreEqual(owner.OwnerId, result.OwnerId);
                Assert.AreEqual(owner.OwnerName, result.OwnerName);
                Assert.AreEqual(owner.PayCode, result.PayCode);
                Assert.AreEqual(owner.SuspenseReason, result.SuspenseReason);
                Assert.AreEqual(owner.InterestType, result.InterestType);
                Assert.AreEqual(owner.NriDecimal, result.NriDecimal);
                Assert.AreEqual(owner.BurdenGroupId, result.BurdenGroupId);
                Assert.AreEqual(owner.EffectiveFromDate, result.EffectiveFromDate);
                Assert.AreEqual(owner.EffectiveToDate, result.EffectiveToDate);
                Assert.AreEqual(owner.CreatedDate, result.CreatedDate);
                Assert.AreEqual(owner.Organization, result.Organization);
                Assert.AreEqual(owner.DoiHeader, result.DoiHeader);
            }
        }
    }
}
