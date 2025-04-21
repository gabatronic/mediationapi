namespace Mediation.Auth.Domain;

public class User
{
    public Guid Id { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string Name { get; init; }
    
    public ICollection<Role> Roles { get; init; } = new List<Role>();
}