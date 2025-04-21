using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.Role.List;

public class ListRolesEndpoint(RoleService roleService) : EndpointWithoutRequest<List<RoleResponse>>
{
    public override void Configure()
    {
        Get("/api/roles");
        Description(e => e.WithTags("Roles"));
        Summary(s => 
        {
            s.Summary = "Get all roles";
            s.Description = "Retrieves all roles in the system";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var roles = await roleService.GetAllRoles();
        
        var response = roles.Select(r => new RoleResponse(r.Id, r.Name, r.Description)).ToList();
        
        await SendOkAsync(response, ct);
    }
}