using mediation.mediations.Domain;
using Microsoft.EntityFrameworkCore;

namespace mediation.mediations.Infrastructure.Persistence;

public class PostgresMediationTermsRepository(MediationDbContext dbContext) : IMediationTermsRepository
{
    public async Task<bool> CreateJurisdiction(Jurisdiction jurisdiction)
    {
        await dbContext.Jurisdictions.AddAsync(jurisdiction);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateJurisdiction(Jurisdiction jurisdiction)
    {
        dbContext.Jurisdictions.Update(jurisdiction);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteJurisdiction(string name)
    {
        var jurisdiction = await dbContext.Jurisdictions.FirstOrDefaultAsync(j => j.Name == name);
        if (jurisdiction == null) return false;
        
        dbContext.Jurisdictions.Remove(jurisdiction);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Jurisdiction?> GetJurisdiction(Guid id)
    {
        return await dbContext.Jurisdictions.FindAsync(id);
    }

    public async Task<IEnumerable<Jurisdiction>> GetAllJurisdictions()
    {
        return await dbContext.Jurisdictions.ToListAsync();
    }

    public async Task<bool> CreateScope(Scope scope)
    {
        await dbContext.Scopes.AddAsync(scope);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateScope(Scope scope)
    {
        dbContext.Scopes.Update(scope);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteScope(string name)
    {
        var scope = await dbContext.Scopes.FirstOrDefaultAsync(s => s.Name == name);
        if (scope == null) return false;
        
        dbContext.Scopes.Remove(scope);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Scope?> GetScope(Guid id)
    {
        return await dbContext.Scopes.FindAsync(id);
    }

    public async Task<IEnumerable<Scope>> GetAllScopes(Guid jurisdictionId)
    {
        return await dbContext.Scopes
            .Where(s => s.JurisdictionId == jurisdictionId)
            .ToListAsync();
    }

    public async Task<bool> CreateTopology(Topology topology)
    {
        await dbContext.Topologies.AddAsync(topology);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateTopology(Topology topology)
    {
        dbContext.Topologies.Update(topology);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteTopology(string name)
    {
        var topology = await dbContext.Topologies.FirstOrDefaultAsync(t => t.Name == name);
        if (topology == null) return false;
        
        dbContext.Topologies.Remove(topology);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Topology?> GetTopology(Guid id)
    {
        return await dbContext.Topologies.FindAsync(id);
    }

    public async Task<IEnumerable<Topology>> GetAllTopologies(Guid scopeId)
    {
        return await dbContext.Topologies
            .Where(t => t.ScopeId == scopeId)
            .ToListAsync();
    }
}