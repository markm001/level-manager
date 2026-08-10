namespace LevelManager.Core.Models;

public sealed record CostCurve(
    string Id,
    IReadOnlyList<CostRequirement> Requirements)
{
    public IReadOnlyList<ResourceCost> GetCostRequired(int level)
    {
        var requirement = Requirements.First(x => x.Level == level);
        
        if (requirement is null)
        {
            throw new InvalidOperationException(
                $"Cost curve '{Id}' does not contain requirement for level {level}.");
        }
        
        return requirement.Resources;
    }
}

public sealed record CostRequirement(
    int Level,
    IReadOnlyList<ResourceCost> Resources
);