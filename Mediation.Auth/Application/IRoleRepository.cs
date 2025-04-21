using Mediation.Auth.Domain;

namespace Mediation.Auth.Application;

public interface IRoleRepository
{
    public Task<bool> AssignRole(Guid userId, Guid roleId);
    public Task<bool> UnassignRole(Guid userId, Guid roleId);
    public Task<bool> Add(Role role);
    public Task<bool> Remove(Guid id);
    public Task<bool> Update(Role role);
    public Task<IEnumerable<Role>> GetAll();
}