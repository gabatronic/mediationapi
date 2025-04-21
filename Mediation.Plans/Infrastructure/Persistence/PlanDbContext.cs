using Mediation.Plans.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mediation.Plans.Infrastructure.Persistence;

public class PlanDbContext(DbContextOptions<PlanDbContext> options) : DbContext(options)
{
    public DbSet<Plan> Plans { get; set; } = null!;
    public DbSet<PlanFeature> PlanFeatures { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and constraints
        modelBuilder.Entity<PlanFeature>()
            .HasKey(pf => new { pf.PlanId, pf.Id });
            
        modelBuilder.Entity<PlanFeature>()
            .HasOne<Plan>()
            .WithMany(p => p.Features)
            .HasForeignKey(pf => pf.PlanId);
    }
}