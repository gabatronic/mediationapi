using mediation.mediations.Domain;

namespace mediation.mediations.Infrastructure.Persistence;

public class PostgresMediationRepository : IMediationRepository
{
    public async Task<bool> Create(Mediation mediation)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Mediation mediation)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(Mediation mediation)
    {
        throw new NotImplementedException();
    }

    public async Task<Mediation?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Mediation>> GetAll()
    {
        throw new NotImplementedException();
    }
}