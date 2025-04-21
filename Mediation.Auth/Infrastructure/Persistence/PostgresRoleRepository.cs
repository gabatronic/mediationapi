using Mediation.Auth.Application;
using Mediation.Auth.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mediation.Auth.Infrastructure.Persistence;

public class PostgresRoleRepository(AuthDbContext dbContext) : IRoleRepository
{
    public async Task<bool> AssignRole(Guid userId, Guid roleId)
    {
        var user = await dbContext.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        if (user == null) return false;
        
        var role = await dbContext.Roles.FindAsync(roleId);
        if (role == null) return false;

        if (!user.Roles.Any(r => r.Id == roleId))
        {
            // Create a new user with the updated roles
            var updatedRoles = new List<Role>(user.Roles) { role };
            var updatedUser = new User
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Roles = updatedRoles
            };
            
            dbContext.Users.Remove(user);
            await dbContext.Users.AddAsync(updatedUser);
            return await dbContext.SaveChangesAsync() > 0;
        }
        
        return true;
    }

    public async Task<bool> UnassignRole(Guid userId, Guid roleId)
    {
        var user = await dbContext.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        if (user == null) return false;
        
        var role = user.Roles.FirstOrDefault(r => r.Id == roleId);
        if (role == null) return true;

        // Create a new user with the updated roles
        var updatedRoles = user.Roles.Where(r => r.Id != roleId).ToList();
        var updatedUser = new User
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            Roles = updatedRoles
        };
        
        dbContext.Users.Remove(user);
        await dbContext.Users.AddAsync(updatedUser);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Add(Role role)
    {
        await dbContext.Roles.AddAsync(role);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Remove(Guid id)
    {
        var role = await dbContext.Roles.FindAsync(id);
        if (role == null) return false;
        
        dbContext.Roles.Remove(role);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(Role role)
    {
        dbContext.Roles.Update(role);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        return await dbContext.Roles.ToListAsync();
    }
}