using FastEndpoints;
using Mediation.Auth.Application;
using Mediation.Auth.Domain;
using Microsoft.AspNetCore.Builder;

namespace Mediation.Auth.Infrastructure.Api.Role.Update;

public class UpdateRoleEndpoint(IRoleRepository roleRepository) : Endpoint<UpdateRoleRequest>
{
    public override void Configure()
    {
        Put("/api/roles/{Id}");
        Description(e => e.WithGroupName("Roles"));
    }

    public override async Task HandleAsync(UpdateRoleRequest req, CancellationToken ct)
    {
        var role = new Role
        {
            Id = req.Id,
            Name = req.Name,
            Description = req.Description
        };

        var result = await roleRepository.Update(role);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendNotFoundAsync(ct);
    }
}