using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;

namespace Mediation.Auth.Infrastructure.Api.User.ResetPassword;

public class ResetPasswordEndpoint(UserService userService) : Endpoint<ResetPasswordRequest>
{
    public override void Configure()
    {
        Post("/api/users/reset-password");
        Description(e => e.WithGroupName("Users"));
    }

    public override async Task HandleAsync(ResetPasswordRequest req, CancellationToken ct)
    {
        var result = await userService.ResetPassword(req.Email);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendNotFoundAsync(ct);
    }
}