using Microsoft.EntityFrameworkCore;
using OfferService.Database.Configuration;
using OfferService.Database.Entities;

namespace OfferService.Database.DbContext;
public class OfferDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public OfferDbContext(DbContextOptions<OfferDbContext> options) : base(options) { }
    
    public DbSet<OfferEntity> Offers { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new OfferEntityConfiguration());
    }
}