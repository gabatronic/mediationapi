using Mediation.Auth.Application;
using Mediation.Auth.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mediation.Auth.Infrastructure.Persistence;

public class PostGresUserRepository(AuthDbContext dbContext) : IUserRepository
{
    public async Task<bool> Add(User user)
    {
        await dbContext.Users.AddAsync(user);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(User user)
    {
        dbContext.Users.Update(user);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Guid userId)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user == null) return false;
        
        dbContext.Users.Remove(user);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> ChangePassword(Guid userId, string newPassword)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user == null) return false;
        
        // Create a new user object with the updated password
        // since password is init-only
        var updatedUser = new User
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Password = newPassword,
            Roles = user.Roles
        };
        
        dbContext.Users.Remove(user);
        await dbContext.Users.AddAsync(updatedUser);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await dbContext.Users
            .Include(u => u.Roles)
            .ToListAsync();
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await dbContext.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}