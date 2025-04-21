using Mediation.Auth.Domain;

namespace Mediation.Auth.Application;

public class RoleService(IRoleRepository roleRepository)
{
    public async Task<bool> CreateRole(Guid id, string name, string description = "")
    {
        var role = new Role
        {
            Id = id,
            Name = name,
            Description = description
        };
        
        return await roleRepository.Add(role);
    }
    
    public async Task<bool> DeleteRole(Guid id)
    {
        return await roleRepository.Remove(id);
    }
    
    public async Task<bool> UpdateRole(Guid id, string name, string description)
    {
        var role = new Role
        {
            Id = id,
            Name = name,
            Description = description
        };
        
        return await roleRepository.Update(role);
    }
    
    public async Task<bool> AssignRole(Guid userId, Guid roleId)
    {
        return await roleRepository.AssignRole(userId, roleId);
    }

    public async Task<bool> UnassignRole(Guid userId, Guid roleId)
    {
        return await roleRepository.UnassignRole(userId, roleId);
    }
    
    public async Task<IEnumerable<Role>> GetAllRoles()
    {
        return await roleRepository.GetAll();
    }
}