namespace Mediation.Auth.Infrastructure.Api.Role.UnassignRole;

public record UnassignRoleRequest(Guid UserId, Guid RoleId);