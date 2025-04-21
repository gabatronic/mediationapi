using System.Security.Cryptography;
using System.Text;
using Mediation.Auth.Domain;

namespace Mediation.Auth.Application;

public class UserService(IUserRepository userRepository, ITokenService tokenService)
{
    public async Task<string?> Authenticate(string email, string password)
    {
        var user = await userRepository.GetByEmail(email);
        if (user == null) return null;
        
        var hashedPassword = HashPassword(password);
        if (user.Password != hashedPassword) return null;
        
        return await tokenService.Generate(user);
    }

    public async Task<bool> Register(string email, string password, string name)
    {
        var existingUser = await userRepository.GetByEmail(email);
        if (existingUser != null) return false;
        
        var hashedPassword = HashPassword(password);
        
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Password = hashedPassword,
            Name = name
        };
        
        return await userRepository.Add(newUser);
    }

    public async Task<bool> ChangePassword(string email, string oldPassword, string newPassword)
    {
        var user = await userRepository.GetByEmail(email);
        if (user == null) return false;
        
        var hashedOldPassword = HashPassword(oldPassword);
        if (user.Password != hashedOldPassword) return false;
        
        var hashedNewPassword = HashPassword(newPassword);
        return await userRepository.ChangePassword(user.Id, hashedNewPassword);
    }
    
    public async Task<bool> ResetPassword(string email) 
    {
        var user = await userRepository.GetByEmail(email);
        if (user == null) return false;
        
        // In a real implementation, you would:
        // 1. Generate a random password or token
        // 2. Send it via email
        // 3. Set an expiration time
        
        // For this implementation, we'll just set a default password
        var defaultPassword = "ResetPassword123!";
        var hashedPassword = HashPassword(defaultPassword);
        
        return await userRepository.ChangePassword(user.Id, hashedPassword);
    }
    
    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}