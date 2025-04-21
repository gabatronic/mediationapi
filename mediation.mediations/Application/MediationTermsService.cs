using mediation.mediations.Domain;
using mediation.mediations.Infrastructure.Api.Jurisdiction.Create;
using mediation.mediations.Infrastructure.Api.Scope;

namespace mediation.mediations.Application;

public class MediationTermsService(IMediationTermsRepository  mediationTermsRepository)
{
    public async Task<bool> CreateJurisdiction(Guid jurisdictionId, string name)
    {
        var jurisdiction = await mediationTermsRepository.GetJurisdiction(jurisdictionId);
        if (jurisdiction != null)
        {
            throw new ArgumentException($"Jurisdiction with id {jurisdictionId} already exists");
        }
        
        return await mediationTermsRepository.CreateJurisdiction(new Jurisdiction()
        {
            Id = jurisdictionId,
            Name = name
        });
    }
    
    public async Task<bool> CreateScope(Guid jurisdictionId, Guid id, string name)
    {
        var jurisdiction = await mediationTermsRepository.GetJurisdiction(jurisdictionId);
        if (jurisdiction == null)
        {
            throw new ArgumentException($"Jurisdiction with id {jurisdictionId} not found");
        }

        var scopeExists = await mediationTermsRepository.GetScope(id);
        if (scopeExists != null)
        {
            throw new ArgumentException($"Scope with id {id} already exists");
        }

        return await mediationTermsRepository.CreateScope(new Scope()
        {
            JurisdictionId = jurisdictionId,
            Id = id,
            Name = name
        });
    }

    public async Task<bool> UpdateScope(Guid id, string name)
    {
        var scopeExists = await mediationTermsRepository.GetScope(id);
        if (scopeExists == null)
        {
            throw new ArgumentException($"Scope with id {id} does not exists");
        }
        scopeExists.Name = name;

        return await mediationTermsRepository.UpdateScope(scopeExists);
    }
    
    public async Task<bool> DeleteScope(Guid id) => await mediationTermsRepository.DeleteScope(id);

    public async Task<IEnumerable<Scope>> GetScopes(Guid jurisdictionId)
    {
        var jurisdictionExists = await mediationTermsRepository.GetJurisdiction(jurisdictionId);
        if (jurisdictionExists == null)
            throw new ArgumentException($"Jurisdiction with id {jurisdictionId} not found");
        
        return await mediationTermsRepository.GetAllScopes(jurisdictionId);
    }

    public async Task<bool> UpdateJurisdiction(Guid id, string name)
    {
        var jurisdiction = await mediationTermsRepository.GetJurisdiction(id);
        if (jurisdiction == null)
            throw new ArgumentException($"Jurisdiction with id {id} not found");
        
        jurisdiction.Name = name;
        return await mediationTermsRepository.UpdateJurisdiction(jurisdiction);
    }

    public async Task<bool> CreateTopology(Guid scopeId, Guid id, string name)
    {
        var scope = await mediationTermsRepository.GetScope(scopeId);
        if (scope == null)
            throw new ArgumentException($"Scope with id {scopeId} not found");
            
        var topology = new Domain.Topology
        {
            Id = id,
            Name = name,
            ScopeId = scopeId
        };
    
        return await mediationTermsRepository.CreateTopology(topology);
    }

    public async Task<bool> UpdateTopology(Guid id, string name)
    {
        var topology = await mediationTermsRepository.GetTopology(id);
        if (topology == null)
            throw new ArgumentException($"Topology with id {id} not found");
            
        topology.Name = name;
        return await mediationTermsRepository.UpdateTopology(topology);
    }

    public async Task<bool> DeleteTopology(Guid id)
    {
        var topology = await mediationTermsRepository.GetTopology(id);
        if (topology == null)
            throw new ArgumentException($"Topology with id {id} not found");
            
        return await mediationTermsRepository.DeleteTopology(topology.Name);
    }

    public async Task<Jurisdiction?> GetJurisdiction(Guid id) => await mediationTermsRepository.GetJurisdiction(id);

    public async Task<bool> DeleteJurisdiction(Guid id)
    {
        var jurisdiction = await mediationTermsRepository.GetJurisdiction(id);
        if (jurisdiction == null)
            throw new ArgumentException($"Jurisdiction with id {id} not found");
            
        return await mediationTermsRepository.DeleteJurisdiction(jurisdiction.Name);
    }
}