using DOService.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DOService.Tests.FakeDbContexts.DoiOwnerContext
{
    public sealed class DoiOwnerContext : DbContext
    {
        private DOServiceContext _context;

        public DOServiceContext ServiceContext => _context;

        public DoiOwnerContext(string testName)
        {
            _context = new DOServiceContext(
                new DbContextOptionsBuilder<DOServiceContext>()
                    .UseInMemoryDatabase(databaseName: testName)
                    .Options);
        }

        public void SeedDatabase()
        {
            var organization = new Organization { Name = "DOI Owner Test Org" };
            ServiceContext.Organizations.Add(organization);

            var doiHeader = new DoiHeader
            {
                Id = Guid.NewGuid(),
                Description = "Test DOI Header",
                ApprovedFlag = true,
                ApprovedDate = DateTime.Today,
                ApprovedUserId = "Test User",
                CreatedDate = DateTime.Today,
                OrganizationId = organization.Id,
                Organization = organization
            };
            ServiceContext.DoiHeaders.Add(doiHeader);

            var payOwner = new DoiOwner
            {
                Id = Guid.NewGuid(),
                OrganizationId = organization.Id,
                DoiHeaderId = doiHeader.Id,
                OwnerId = Guid.NewGuid(),
                OwnerName = "Payed Owner",
                PayCode = "pay",
                SuspenseReason = "executed",
                InterestType = "RI",
                NriDecimal = Convert.ToDecimal(0.5),
                BurdenGroupId = Guid.NewGuid(),
                EffectiveFromDate = DateTime.Today,
                EffectiveToDate = DateTime.Today.AddYears(1),
                CreatedDate = DateTime.Today,
                Organization = organization,
                DoiHeader = doiHeader
            };
            ServiceContext.DoiOwners.Add(payOwner);

            var suspenseOwner = new DoiOwner
            {
                Id = Guid.NewGuid(),
                OrganizationId = organization.Id,
                DoiHeaderId = doiHeader.Id,
                OwnerId = Guid.NewGuid(),
                OwnerName = "Owner in Suspense",
                PayCode = "suspense",
                SuspenseReason = "hold",
                InterestType = "RI",
                NriDecimal = Convert.ToDecimal(0.5),
                BurdenGroupId = Guid.NewGuid(),
                EffectiveFromDate = DateTime.Today,
                EffectiveToDate = DateTime.Today.AddYears(1),
                CreatedDate = DateTime.Today,
                Organization = organization,
                DoiHeader = doiHeader
            };
            ServiceContext.DoiOwners.Add(suspenseOwner);

            ServiceContext.SaveChanges();
        }
    }
}