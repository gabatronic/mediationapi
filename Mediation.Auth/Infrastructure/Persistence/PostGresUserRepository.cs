using Mediation.Auth.Application;
using Mediation.Auth.Domain;

namespace Mediation.Auth.Infrastructure.Persistence;

public class PostGresUserRepository : IUserRepository
{
    public Task<bool> Add(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangePassword(Guid userId, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }
}