namespace Mediation.Auth.Infrastructure.Api.User.Get;

public record UserRole(Guid Id, string Name, string Description);
public record UserResponse(Guid Id, string Email, string Name, List<UserRole> Roles);