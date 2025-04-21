namespace Mediation.Auth.Application;

public class UserService(ITokenService tokenService)
{
    public async Task<bool> Authenticate(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Register(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ChangePassword(string email, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> ResetPassword(string email) 
    {
        throw new NotImplementedException();
    }   
}