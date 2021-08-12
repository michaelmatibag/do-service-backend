using DOService.Controllers;
using DOService.Features.DoiOwnerRepository;
using DOService.Models;
using DOService.Tests.FakeDbContexts.DoiOwnerContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DOService.Tests.DoiOwnerTests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void AddDoiOwner_ShouldAddDoiOwner()
        {
            using (var context = new DoiOwnerContext("PostTests.AddDoiOwner"))
            {
                context.SeedDatabase();
                var organization = context.ServiceContext.Organizations.First();
                var doiHeader = context.ServiceContext.DoiHeaders.FirstOrDefault(dh => dh.OrganizationId == organization.Id);

                var doiOwnerRequest = new DoiOwnerRequest
                {
                    OrganizationId = organization.Id,
                    DoiHeaderId = doiHeader.Id,
                    OwnerId = Guid.NewGuid(),
                    OwnerName = "Test Owner",
                    PayCode = "pay",
                    SuspenseReason = "executed",
                    InterestType = "RI",
                    NriDecimal = 1,
                    BurdenGroupId = Guid.NewGuid(),
                    EffectiveFromDate = DateTime.Today,
                    EffectiveToDate = DateTime.Today.AddYears(1)
                };

                var action = new DoiOwnerController(null, new DoiOwnerRepository(context.ServiceContext)).AddDoiOwner(doiOwnerRequest).Result as OkObjectResult;

                var result = action.Value as DoiOwnerResponse;

                Assert.AreEqual(doiOwnerRequest.OrganizationId, result.OrganizationId);
                Assert.AreEqual(doiOwnerRequest.DoiHeaderId, result.DoiHeaderId);
                Assert.AreEqual(doiOwnerRequest.OwnerId, result.OwnerId);
                Assert.AreEqual(doiOwnerRequest.OwnerName, result.OwnerName);
                Assert.AreEqual(doiOwnerRequest.InterestType, result.InterestType);
                Assert.AreEqual(doiOwnerRequest.NriDecimal, result.NriDecimal);
            }
        }
    }
}
