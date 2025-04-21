using Mediation.Auth.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mediation.Auth.Infrastructure.Persistence;

public class AuthDbContext(DbContextOptions<AuthDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure many-to-many relationship between User and Role
        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany();
            
        // Configure email to be unique
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}