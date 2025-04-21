using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;

namespace Mediation.Auth.Infrastructure.Api.Role.UnassignRole;

public class UnassignRoleEndpoint(IRoleRepository roleRepository) : Endpoint<UnassignRoleRequest>
{
    public override void Configure()
    {
        Post("/api/roles/unassign");
        Description(e => e.WithGroupName("Roles"));
    }

    public override async Task HandleAsync(UnassignRoleRequest req, CancellationToken ct)
    {
        var result = await roleRepository.UnassignRole(req.UserId, req.RoleId);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}