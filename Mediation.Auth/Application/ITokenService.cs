using Mediation.Auth.Domain;

namespace Mediation.Auth.Application;

public interface ITokenService
{
    public Task<string> Generate(User user);
    public Task<bool> Verify(string token);
    public Task<bool> Revoke(string token);
    
    public Task<string> Refresh(string accessToken, string refreshToken);
}