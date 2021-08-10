using Microsoft.EntityFrameworkCore;

namespace DOService.Models
{
    public class DOServiceContext : DbContext
    {
        public DOServiceContext(DbContextOptions<DOServiceContext> options) : base(options)
        { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<DoiHeader> DoiHeaders { get; set;}
        public DbSet<DoiOwner> DoiOwners { get; set;}
    }
}
