using FastEndpoints;
using Mediation.Auth.Application;
using Mediation.Auth.Domain;
using Microsoft.AspNetCore.Builder;

namespace Mediation.Auth.Infrastructure.Api.Role.Create;

public class CreateRoleEndpoint(IRoleRepository roleRepository) : Endpoint<CreateRoleRequest>
{
    public override void Configure()
    {
        Post("/api/roles");
        Description(e => e.WithGroupName("Roles"));
    }

    public override async Task HandleAsync(CreateRoleRequest req, CancellationToken ct)
    {
        var role = new Role
        {
            Id = req.Id,
            Name = req.Name,
            Description = req.Description
        };

        var result = await roleRepository.Add(role);
        
        if (result)
            await SendCreatedAtAsync("/api/roles", null, ct);
        else
            await SendErrorsAsync(400, ct);
    }
}