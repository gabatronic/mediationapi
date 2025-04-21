using Mediation.Auth.Application;
using Mediation.Auth.Domain;

namespace Mediation.Auth.Infrastructure.Persistence;

public class PostgresRoleRepository : IRoleRepository
{
    public Task<bool> AssignRole(Guid userId, Guid roleId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UnassignRole(Guid userId, Guid roleId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Add(Role role)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Role role)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Role>> GetAll()
    {
        throw new NotImplementedException();
    }
}