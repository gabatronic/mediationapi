using mediation.mediations.Domain;

namespace mediation.mediations.Infrastructure.Persistence;

public class PostgresDefendantRepository : IDefendantRepository
{
    public async Task<bool> Create(Defendant defendant)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Defendant defendant)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(Defendant defendant)
    {
        throw new NotImplementedException();
    }

    public async Task<Defendant?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Defendant>> GetAll()
    {
        throw new NotImplementedException();
    }
}