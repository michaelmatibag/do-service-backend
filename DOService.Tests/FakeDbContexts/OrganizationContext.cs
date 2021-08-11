using DOService.Models;
using Microsoft.EntityFrameworkCore;

namespace DOService.Tests.FakeDbContexts.OrganizationContext
{
    public sealed class OrganizationContext : DbContext
    {
        private DOServiceContext _context;

        public DOServiceContext DbContext { get { return _context; } }

        public OrganizationContext(string testName)
        {
            var options = new DbContextOptionsBuilder<DOServiceContext>()
                .UseInMemoryDatabase(databaseName: testName)
                .Options;

            _context = new DOServiceContext(options);
        }

        public void SeedDatabase()
        {
            DbContext.Organizations.Add(new Organization { Name = "Test Org 1" });
            DbContext.Organizations.Add(new Organization { Name = "Test Org 2" });
            DbContext.Organizations.Add(new Organization { Name = "Test Org 3" });
            DbContext.SaveChanges();
        }
    }
}