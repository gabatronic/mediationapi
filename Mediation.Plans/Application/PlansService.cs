using Mediation.Plans.Domain;

namespace Mediation.Plans.Application;

public class PlansService(IPlanRepository repository)
{
    public async Task<IEnumerable<Plan>> GetAllPlans()
    {
        return await repository.GetAllAsync();
    }
    
    public async Task<Plan?> GetPlanById(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }
    
    public async Task<bool> CreatePlan(Guid id, string name, string description = "", double cost = 0)
    {
        var planExists = await repository.GetByIdAsync(id);
        if (planExists != null)
            throw new ArgumentException($"Plan with id {id} already exists");
        
        return await repository.CreateAsync(new Plan 
        { 
            Id = id, 
            Name = name,
            Description = description,
            Cost = cost
        });
    }
    
    public async Task<bool> UpdatePlan(Guid id, string name, string description, double cost)
    {
        var plan = await repository.GetByIdAsync(id);
        if (plan == null)
            throw new ArgumentException($"Plan with id {id} not found");
            
        plan.Name = name;
        plan.Description = description;
        plan.Cost = cost;
        
        return await repository.UpdateAsync(plan);
    }
    
    public async Task<bool> DeletePlan(Guid id)
    {
        var plan = await repository.GetByIdAsync(id);
        if (plan == null)
            throw new ArgumentException($"Plan with id {id} not found");
            
        return await repository.DeleteAsync(id);
    }
    
    public async Task<bool> AddFeatureToPlan(Guid planId, Guid featureId, string description)
    {
        var plan = await repository.GetByIdAsync(planId);
        if (plan == null)
            throw new ArgumentException($"Plan with id {planId} not found");
            
        return await repository.AddFeatureAsync(planId, featureId, description);
    }
    
    public async Task<bool> RemoveFeatureFromPlan(Guid planId, Guid featureId)
    {
        var plan = await repository.GetByIdAsync(planId);
        if (plan == null)
            throw new ArgumentException($"Plan with id {planId} not found");
            
        return await repository.RemoveFeatureAsync(planId, featureId);
    }
}