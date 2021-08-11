using DOService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

public class FakeOrgContext : DbContext
{
    public DbSet<Organization> Organizations { get; set; }

    //public override 
}