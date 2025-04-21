using mediation.mediations.Domain;
using Microsoft.EntityFrameworkCore;

namespace mediation.mediations.Infrastructure.Persistence;

public class PostgresMediationRepository(MediationDbContext dbContext) : IMediationRepository
{
    public async Task<bool> Create(Mediation mediation)
    {
        await dbContext.Mediations.AddAsync(mediation);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(Mediation mediation)
    {
        dbContext.Mediations.Update(mediation);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var mediation = await dbContext.Mediations.FindAsync(id);
        if (mediation == null)
            return false;   
        
        dbContext.Mediations.Remove(mediation);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Mediation?> GetById(Guid id)
    {
        return await dbContext.Mediations.FindAsync(id);
    }

    public async Task<IEnumerable<Mediation>> GetAll()
    {
        return await dbContext.Mediations.ToListAsync();
    }
}