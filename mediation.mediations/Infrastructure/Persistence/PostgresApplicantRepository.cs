using mediation.mediations.Domain;

namespace mediation.mediations.Infrastructure.Persistence;

public class PostgresApplicantRepository : IApplicantRepository
{
    public async Task<bool> Create(Applicant defendant)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Update(Applicant defendant)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Delete(Applicant defendant)
    {
        throw new NotImplementedException();
    }

    public async Task<Applicant?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Applicant?> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Applicant>> GetAll()
    {
        throw new NotImplementedException();
    }
}