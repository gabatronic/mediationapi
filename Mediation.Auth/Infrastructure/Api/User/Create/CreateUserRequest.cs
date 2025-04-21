namespace Mediation.Auth.Infrastructure.Api.User.Create;

public record CreateUserRequest(string Email, string Password, string Name);