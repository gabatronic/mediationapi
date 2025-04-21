using Mediation.Plans.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mediation.Plans.Infrastructure.Persistence;

public class PostgresPlanRepository(PlanDbContext dbContext) : IPlanRepository
{
    public async Task<IEnumerable<Plan>> GetAllAsync()
    {
        return await dbContext.Plans
            .Include(p => p.Features)
            .ToListAsync();
    }

    public async Task<Plan?> GetByIdAsync(Guid planId)
    {
        return await dbContext.Plans
            .Include(p => p.Features)
            .FirstOrDefaultAsync(p => p.Id == planId);
    }

    public async Task<bool> CreateAsync(Plan plan)
    {
        await dbContext.Plans.AddAsync(plan);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Plan plan)
    {
        dbContext.Plans.Update(plan);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid planId)
    {
        var plan = await dbContext.Plans.FindAsync(planId);
        if (plan == null) return false;
        
        dbContext.Plans.Remove(plan);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddFeatureAsync(Guid planId, Guid featureId, string description)
    {
        var plan = await dbContext.Plans.FindAsync(planId);
        if (plan == null) return false;
        
        var feature = new PlanFeature
        {
            PlanId = planId,
            Id = featureId,
            Description = description
        };
        
        await dbContext.PlanFeatures.AddAsync(feature);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveFeatureAsync(Guid planId, Guid featureId)
    {
        var feature = await dbContext.PlanFeatures
            .FirstOrDefaultAsync(pf => pf.PlanId == planId && pf.Id == featureId);
        
        if (feature == null) return false;
        
        dbContext.PlanFeatures.Remove(feature);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateFeatureAsync(PlanFeature feature)
    {
        dbContext.PlanFeatures.Update(feature);
        return await dbContext.SaveChangesAsync() > 0;
    }
}