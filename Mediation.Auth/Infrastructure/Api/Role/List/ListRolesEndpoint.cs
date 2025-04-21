using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;

namespace Mediation.Auth.Infrastructure.Api.Role.List;

public class ListRolesEndpoint(IRoleRepository roleRepository) : EndpointWithoutRequest<List<RoleResponse>>
{
    public override void Configure()
    {
        Get("/api/roles");
        Description(e => e.WithGroupName("Roles"));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var roles = await roleRepository.GetAll();
        
        var response = roles.Select(r => new RoleResponse(r.Id, r.Name, r.Description)).ToList();
        
        await SendOkAsync(response, ct);
    }
}