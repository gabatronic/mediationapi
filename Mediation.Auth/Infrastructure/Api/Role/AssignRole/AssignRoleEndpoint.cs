using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.Role.AssignRole;

public class AssignRoleEndpoint(RoleService roleService) : Endpoint<AssignRoleRequest>
{
    public override void Configure()
    {
        Post("/api/roles/assign");
        Description(e => e.WithTags("Roles"));
        Summary(s => 
        {
            s.Summary = "Assign a role to a user";
            s.Description = "Assigns a specific role to a user";
        });
    }

    public override async Task HandleAsync(AssignRoleRequest req, CancellationToken ct)
    {
        var result = await roleService.AssignRole(req.UserId, req.RoleId);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}