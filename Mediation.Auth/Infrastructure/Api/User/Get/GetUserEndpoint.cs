using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.User.Get;

public class GetUserEndpoint(IUserRepository userRepository) : Endpoint<GetUserRequest, UserResponse>
{
    public override void Configure()
    {
        Get("/api/users/{Email}");
        Description(e => e.WithTags("Users"));
    }

    public override async Task HandleAsync(GetUserRequest req, CancellationToken ct)
    {
        var user = await userRepository.GetByEmail(req.Email);
        
        if (user == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var roleResponses = user.Roles
            .Select(r => new UserRole(r.Id, r.Name, r.Description))
            .ToList();

        await SendOkAsync(new UserResponse(
            user.Id,
            user.Email,
            user.Name,
            roleResponses), ct);
    }
}