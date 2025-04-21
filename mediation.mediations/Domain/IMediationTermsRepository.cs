namespace mediation.mediations.Domain;

public interface IMediationTermsRepository
{
    public Task<bool> CreateJurisdiction(Jurisdiction jurisdiction);
    public Task<bool> UpdateJurisdiction(Jurisdiction jurisdiction);
    public Task<bool> DeleteJurisdiction(string name);
    public Task<Jurisdiction?> GetJurisdiction(Guid id);
    public Task<IEnumerable<Jurisdiction>> GetAllJurisdictions();
    
    public Task<bool> CreateScope(Scope scope);
    public Task<bool> UpdateScope(Scope scope);
    public Task<bool> DeleteScope(Guid id);
    public Task<Scope?> GetScope(Guid id);
    public Task<IEnumerable<Scope>> GetAllScopes(Guid jurisdictionId);
    
    public Task<bool> CreateTopology(Topology topology);
    public Task<bool> UpdateTopology(Topology topology);
    public Task<bool> DeleteTopology(string name);
    public Task<Topology?> GetTopology(Guid id);
    public Task<IEnumerable<Topology>> GetAllTopologies(Guid scopeId);
}