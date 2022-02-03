namespace RUG.WebEng.Properties.Models;

using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<Property> Properties {get;set;}
    public DbSet<Location> Locations {get;set;}

    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>()
            .HasOne(p=>p.Location)
            .WithMany(c=>c.Properties);
    }
}