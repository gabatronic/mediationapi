using mediation.mediations.Domain;
using Microsoft.EntityFrameworkCore;

namespace mediation.mediations.Infrastructure.Persistence;

public class MediationDbContext : DbContext
{
    public MediationDbContext(DbContextOptions<MediationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Applicant> Applicants { get; set; } = null!;
    public DbSet<Defendant> Defendants { get; set; } = null!;
    public DbSet<Mediation> Mediations { get; set; } = null!;
    public DbSet<Jurisdiction> Jurisdictions { get; set; } = null!; 
    public DbSet<Scope> Scopes { get; set; } = null!;
    public DbSet<Topology> Topologies { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and constraints here if needed
        modelBuilder.Entity<Scope>()
            .HasOne<Jurisdiction>()
            .WithMany()
            .HasForeignKey(s => s.JurisdictionId);
            
        modelBuilder.Entity<Topology>()
            .HasOne<Scope>()
            .WithMany()
            .HasForeignKey(t => t.ScopeId);
            
        modelBuilder.Entity<Mediation>()
            .HasOne<Applicant>()
            .WithMany()
            .HasForeignKey(m => m.ApplicantId);
            
        modelBuilder.Entity<Mediation>()
            .HasOne<Defendant>()
            .WithMany()
            .HasForeignKey(m => m.DefendantId);
    }
}