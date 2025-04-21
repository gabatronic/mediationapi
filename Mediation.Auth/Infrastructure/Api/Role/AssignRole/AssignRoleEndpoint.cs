using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;

namespace Mediation.Auth.Infrastructure.Api.Role.AssignRole;

public class AssignRoleEndpoint(IRoleRepository roleRepository) : Endpoint<AssignRoleRequest>
{
    public override void Configure()
    {
        Post("/api/roles/assign");
        Description(e => e.WithGroupName("Roles"));
    }

    public override async Task HandleAsync(AssignRoleRequest req, CancellationToken ct)
    {
        var result = await roleRepository.AssignRole(req.UserId, req.RoleId);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}