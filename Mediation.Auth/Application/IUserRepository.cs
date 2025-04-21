using Mediation.Auth.Domain;

namespace Mediation.Auth.Application;

public interface IUserRepository
{
    public Task<bool> Add(User user);
    public Task<bool> Update(User user);
    public Task<bool> Delete(Guid userId);
    public Task<bool> ChangePassword(Guid userId, string newPassword);

    public Task<IEnumerable<User>> GetAll();
    public Task<User> GetByEmail(string email);
}