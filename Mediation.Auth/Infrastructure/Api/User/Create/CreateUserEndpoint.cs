using FastEndpoints;
using Mediation.Auth.Application;

namespace Mediation.Auth.Infrastructure.Api.User.Create;

public class CreateUserEndpoint(UserService userService) : Endpoint<CreateUserRequest>
{
    public override void Configure()
    {
        Post("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        var result = await userService.Register(req.Email, req.Password, req.Name);
        
        if (result)
            await SendCreatedAtAsync("/api/users", null, ct);
        else
            await SendErrorsAsync(400, ct);
    }
}