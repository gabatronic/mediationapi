using Mediation.Auth.Application;
using Mediation.Auth.Domain;

namespace Mediation.Auth.Infrastructure.JwtTokenService;

public class JwtTokenService : ITokenService
{
    public Task<string> Generate(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Verify(string token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Revoke(string token)
    {
        throw new NotImplementedException();
    }

    public Task<string> Refresh(string accessToken, string refreshToken)
    {
        throw new NotImplementedException();
    }
}