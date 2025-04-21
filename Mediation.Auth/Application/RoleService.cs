using Mediation.Auth.Domain;

namespace Mediation.Auth.Application;

public class RoleService(IRoleRepository roleRepository)
{
    public async Task<bool> CreateRole(Guid id, string roleName)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> DeleteRole(Guid id)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> UpdateRole(Guid id)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> AssingRole(Guid userId, Guid roleId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UnassignRole(Guid userId, Guid roleId)
    {
        
    }
    public async Task<List<Role>> GetAllRoles()
    {
        throw new NotImplementedException();
    }
    
}