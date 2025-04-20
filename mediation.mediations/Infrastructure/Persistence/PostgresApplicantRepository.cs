using mediation.mediations.Domain;
using Microsoft.EntityFrameworkCore;

namespace mediation.mediations.Infrastructure.Persistence;

public class PostgresApplicantRepository(MediationDbContext dbContext) : IApplicantRepository
{
    public async Task<bool> Create(Applicant applicant)
    {
        await dbContext.Applicants.AddAsync(applicant);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(Applicant applicant)
    {
        dbContext.Applicants.Update(applicant);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Applicant applicant)
    {
        dbContext.Applicants.Remove(applicant);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Applicant?> GetById(Guid id)
    {
        return await dbContext.Applicants.FindAsync(id);
    }

    public async Task<Applicant?> GetByEmail(string email)
    {
        return await dbContext.Applicants.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<IEnumerable<Applicant>> GetAll()
    {
        return await dbContext.Applicants.ToListAsync();
    }
}