using DemoApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Infrastructure;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    {
    }

    public DbSet<Teacher> Teachers => Set<Teacher>();

    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolDbContext).Assembly);
    }
}