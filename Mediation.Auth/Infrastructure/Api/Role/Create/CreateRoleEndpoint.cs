using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.Role.Create;

public class CreateRoleEndpoint(RoleService roleService) : Endpoint<CreateRoleRequest>
{
    public override void Configure()
    {
        Post("/api/roles");
        Description(e => e.WithTags("Roles"));
        Summary(s => 
        {
            s.Summary = "Create a new role";
            s.Description = "Creates a new role with the specified information";
        });
    }

    public override async Task HandleAsync(CreateRoleRequest req, CancellationToken ct)
    {
        var result = await roleService.CreateRole(req.Id, req.Name, req.Description);
        
        if (result)
            await SendCreatedAtAsync("/api/roles", null, ct);
        else
            await SendErrorsAsync(400, ct);
    }
}