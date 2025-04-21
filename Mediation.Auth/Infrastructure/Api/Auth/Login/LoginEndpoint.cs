using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.Auth.Login;

public class LoginEndpoint(UserService userService) : Endpoint<LoginRequest, LoginResponse>
{
    public override void Configure()
    {
        Post("/api/auth/login");
        Description(e => e.WithGroupName("Auth").WithTags("Login"));
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var token = await userService.Authenticate(req.Email, req.Password);
        
        if (string.IsNullOrEmpty(token))
        {
            await SendUnauthorizedAsync(ct);
            return;
        }
        
        await SendOkAsync(new LoginResponse(token), ct);
    }
}