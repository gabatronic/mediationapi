using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;

namespace Mediation.Auth.Infrastructure.Api.Role.Delete;

public class DeleteRoleEndpoint(IRoleRepository roleRepository) : Endpoint<DeleteRoleRequest>
{
    public override void Configure()
    {
        Delete("/api/roles/{Id}");
        Description(e => e.WithGroupName("Roles"));
    }

    public override async Task HandleAsync(DeleteRoleRequest req, CancellationToken ct)
    {
        var result = await roleRepository.Remove(req.Id);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendNotFoundAsync(ct);
    }
}