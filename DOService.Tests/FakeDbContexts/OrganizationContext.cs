using DOService.Models;
using Microsoft.EntityFrameworkCore;

namespace DOService.Tests.FakeDbContexts.OrganizationContext
{
    public class OrganizationContext : DbContext
    {
        private DbContextOptions<DOServiceContext> _options = new DbContextOptionsBuilder<DOServiceContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        private DOServiceContext _context;

        public DOServiceContext DbContext { get { return _context; } }

        public OrganizationContext()
        {
            _context = new DOServiceContext(_options);
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