using Microsoft.EntityFrameworkCore;
using PCAtranka.Domain.Entities;
using PCAtranka.Infrastructure.Data.Configurations;

namespace PCAtranka.Infrastructure.Data;

public class PCAtrankaDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    
    
    public PCAtrankaDbContext(DbContextOptions<PCAtrankaDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfiguration).Assembly);
    }
}