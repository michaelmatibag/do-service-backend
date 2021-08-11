using DOService.Features.DoiHeaderRepository;
using DOService.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DOService.Tests.FakeDbContexts.DoiHeaderContext
{
    public sealed class DoiHeaderContext : DbContext
    {
        private DOServiceContext _context;
        private DoiHeaderRepository _repository;
        
        public DOServiceContext DbContext => _context;
        public DoiHeaderRepository Repository => _repository;

        public DoiHeaderContext(string testName)
        {
            _context = new DOServiceContext(
                new DbContextOptionsBuilder<DOServiceContext>()
                    .UseInMemoryDatabase(databaseName: testName)
                    .Options);
            _repository = new DoiHeaderRepository(_context);
        }

        public void SeedDatabase()
        {
            var organization = new Organization { Name = "DOI Test Org" };

            DbContext.Organizations.Add(organization);
            DbContext.DoiHeaders.Add(new DoiHeader
            {
                Id = Guid.NewGuid(),
                Description = "Test DOI 1",
                ApprovedFlag = true,
                ApprovedDate = DateTime.Today,
                ApprovedUserId = "Test User",
                CreatedDate = DateTime.Today,
                OrganizationId = organization.Id,
                Organization = organization
            });
            DbContext.DoiHeaders.Add(new DoiHeader
            {
                Id = Guid.NewGuid(),
                Description = "Test DOI 2",
                ApprovedFlag = true,
                ApprovedDate = DateTime.Today,
                ApprovedUserId = "Test User",
                CreatedDate = DateTime.Today,
                OrganizationId = organization.Id,
                Organization = organization
            });
            DbContext.DoiHeaders.Add(new DoiHeader
            {
                Id = Guid.NewGuid(),
                Description = "Test DOI 3",
                ApprovedFlag = true,
                ApprovedDate = DateTime.Today,
                ApprovedUserId = "Test User",
                CreatedDate = DateTime.Today,
                OrganizationId = organization.Id,
                Organization = organization
            });
            DbContext.SaveChanges();
        }
    }
}
