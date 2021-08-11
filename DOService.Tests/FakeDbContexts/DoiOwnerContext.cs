using DOService.Models;
using Microsoft.EntityFrameworkCore;

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

            ServiceContext.Organizations.Add(new Organization { Name = "Test Org 1" });
            ServiceContext.Organizations.Add(new Organization { Name = "Test Org 2" });
            ServiceContext.Organizations.Add(new Organization { Name = "Test Org 3" });
            ServiceContext.SaveChanges();
        }
    }
}