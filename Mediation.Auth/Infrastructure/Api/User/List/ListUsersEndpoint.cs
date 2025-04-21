using FastEndpoints;
using Mediation.Auth.Application;
using Mediation.Auth.Infrastructure.Api.User.Get;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.User.List;

public class ListUsersEndpoint(IUserRepository userRepository) : EndpointWithoutRequest<List<UserResponse>>
{
    public override void Configure()
    {
        Get("/api/users");
        Description(e => e.WithTags("Users"));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var users = await userRepository.GetAll();
        
        var response = users.Select(user => new UserResponse(
            user.Id,
            user.Email,
            user.Name,
            user.Roles.Select(r => new UserRole(r.Id, r.Name, r.Description)).ToList()
        )).ToList();
        
        await SendOkAsync(response, ct);
    }
}