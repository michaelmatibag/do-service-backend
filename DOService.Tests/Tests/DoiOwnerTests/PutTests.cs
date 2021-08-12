using DOService.Controllers;
using DOService.Features.DoiOwnerRepository;
using DOService.Models;
using DOService.Tests.FakeDbContexts.DoiOwnerContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DOService.Tests.DoiOwnerTests
{
    [TestClass]
    public class PutTests
    {
        [TestMethod]
        public void UpdateDoiOwner_ShouldUpdateDoiOwner()
        {
            using (var context = new DoiOwnerContext("PutTests.UpdateDoiOwner"))
            {
                context.SeedDatabase();

                var owner = context.ServiceContext.DoiOwners.First();
                var ownerRequest = new DoiOwnerRequest
                {
                    OrganizationId = owner.Id,
                    DoiHeaderId = owner.DoiHeaderId,
                    OwnerId = owner.OwnerId,
                    OwnerName = "Updated Owner",
                    PayCode = "pay",
                    SuspenseReason = "executed",
                    InterestType = owner.InterestType,
                    NriDecimal = owner.NriDecimal,
                    BurdenGroupId = owner.BurdenGroupId,
                    EffectiveFromDate = owner.EffectiveFromDate,
                    EffectiveToDate = owner.EffectiveToDate
                };

                var action = new DoiOwnerController(null, new DoiOwnerRepository(context.ServiceContext)).UpdateDoiOwner(owner.Id, ownerRequest).Result as OkObjectResult;

                var result = action.Value as DoiOwnerResponse;

                Assert.AreEqual(ownerRequest.OwnerName, result.Id);
                Assert.AreEqual(ownerRequest.PayCode, result.PayCode);
                Assert.AreEqual(ownerRequest.SuspenseReason, result.SuspenseReason);
            }
        }
    }
}
