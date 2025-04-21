using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.Role.UnassignRole;

public class UnassignRoleEndpoint(RoleService roleService) : Endpoint<UnassignRoleRequest>
{
    public override void Configure()
    {
        Post("/api/roles/unassign");
        Description(e => e.WithTags("Roles"));
        Summary(s => 
        {
            s.Summary = "Unassign a role from a user";
            s.Description = "Removes a specific role from a user";
        });
    }

    public override async Task HandleAsync(UnassignRoleRequest req, CancellationToken ct)
    {
        var result = await roleService.UnassignRole(req.UserId, req.RoleId);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}