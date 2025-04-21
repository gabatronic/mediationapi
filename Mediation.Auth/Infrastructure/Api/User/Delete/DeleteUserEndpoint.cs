using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;

namespace Mediation.Auth.Infrastructure.Api.User.Delete;

public class DeleteUserEndpoint(IUserRepository userRepository) : Endpoint<DeleteUserRequest>
{
    public override void Configure()
    {
        Delete("/api/users/{Id}");
        Description(e => e.WithGroupName("Users"));
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        var result = await userRepository.Delete(req.Id);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendNotFoundAsync(ct);
    }
}