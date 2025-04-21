using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.Role.Delete;

public class DeleteRoleEndpoint(RoleService roleService) : Endpoint<DeleteRoleRequest>
{
    public override void Configure()
    {
        Delete("/api/roles/{Id}");
        Description(e => e.WithTags("Roles"));
        Summary(s => 
        {
            s.Summary = "Delete a role";
            s.Description = "Deletes a role based on the provided ID";
        });
    }

    public override async Task HandleAsync(DeleteRoleRequest req, CancellationToken ct)
    {
        var result = await roleService.DeleteRole(req.Id);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendNotFoundAsync(ct);
    }
}