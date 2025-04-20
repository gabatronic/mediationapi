using mediation.mediations.Domain;
using Microsoft.EntityFrameworkCore;

namespace mediation.mediations.Infrastructure.Persistence;

public class PostgresDefendantRepository(MediationDbContext dbContext) : IDefendantRepository
{
    public async Task<bool> Create(Defendant defendant)
    {
        await dbContext.Defendants.AddAsync(defendant);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(Defendant defendant)
    {
        dbContext.Defendants.Update(defendant);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Defendant defendant)
    {
        dbContext.Defendants.Remove(defendant);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Defendant?> GetById(Guid id)
    {
        return await dbContext.Defendants.FindAsync(id);
    }

    public async Task<IEnumerable<Defendant>> GetAll()
    {
        return await dbContext.Defendants.ToListAsync();
    }
}