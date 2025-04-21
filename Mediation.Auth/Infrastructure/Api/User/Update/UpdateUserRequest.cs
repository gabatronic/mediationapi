namespace Mediation.Auth.Infrastructure.Api.User.Update;

public record UpdateUserRequest(Guid Id, string Email, string Name);