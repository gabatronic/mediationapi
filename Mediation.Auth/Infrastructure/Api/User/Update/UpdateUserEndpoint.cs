using FastEndpoints;
using Mediation.Auth.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Mediation.Auth.Infrastructure.Api.User.Update;

public class UpdateUserEndpoint(IUserRepository userRepository) : Endpoint<UpdateUserRequest>
{
    public override void Configure()
    {
        Put("/api/users/{Id}");
        Description(e => e.WithTags("Users"));
    }

    public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
    {
        // Get current user to preserve password and roles
        var currentUser = await userRepository.GetByEmail(req.Email);
        if (currentUser == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        // Create updated user with same password and roles
        var updatedUser = new Domain.User
        {
            Id = req.Id,
            Email = req.Email,
            Name = req.Name,
            Password = currentUser.Password,
            Roles = currentUser.Roles
        };

        var result = await userRepository.Update(updatedUser);
        
        if (result)
            await SendOkAsync(ct);
        else
            await SendErrorsAsync(400, ct);
    }
}