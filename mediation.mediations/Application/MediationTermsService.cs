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
}