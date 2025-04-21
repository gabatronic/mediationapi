using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.Role.Update;

public class UpdateRoleEndpoint(RoleService roleService) : Endpoint<UpdateRoleRequest>
{
    public override void Configure()
    {
        Put("/api/roles/{Id}");
        Description(e => e.WithTags("Roles"));
        Summary(s => 
        {
            s.Summary = "Update an existing role";
            s.Description = "Updates a role with the provided information";
        });
    }

    public override async Task HandleAsync(UpdateRoleRequest req, CancellationToken ct)
    {
        var result = await roleService.UpdateRole(req.Id, req.Name, req.Description);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendNotFoundAsync(ct);
    }
}