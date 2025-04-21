namespace Mediation.Plans.Domain;

public interface IPlanRepository
{
    public Task<IEnumerable<Plan>> GetAllAsync();
    public Task<Plan> GetByIdAsync(Guid planId);
    public Task<bool> CreateAsync(Plan plan);
    public Task<bool> UpdateAsync(Plan plan);
    public Task<bool> DeleteAsync(Guid planId);
    
    public Task<bool> AddFeatureAsync(Guid planId, Guid featureId, string description);
    public Task<bool> RemoveFeatureAsync(Guid planId, Guid featureId);
    public Task<bool> UpdateFeatureAsync(PlanFeature feature);
}