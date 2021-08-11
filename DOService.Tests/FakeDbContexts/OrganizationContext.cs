using DOService.Features.OrganizationRepository;
using DOService.Models;
using Microsoft.EntityFrameworkCore;

namespace DOService.Tests.FakeDbContexts.OrganizationContext
{
    public sealed class OrganizationContext : DbContext
    {
        private DOServiceContext _context;

        public DOServiceContext ServiceContext => _context;

        public OrganizationContext(string testName)
        {
            _context = new DOServiceContext(
                new DbContextOptionsBuilder<DOServiceContext>()
                    .UseInMemoryDatabase(databaseName: testName)
                    .Options);
        }

        public void SeedDatabase()
        {
            ServiceContext.Organizations.Add(new Organization { Name = "Test Org 1" });
            ServiceContext.Organizations.Add(new Organization { Name = "Test Org 2" });
            ServiceContext.Organizations.Add(new Organization { Name = "Test Org 3" });
            ServiceContext.SaveChanges();
        }
    }
}