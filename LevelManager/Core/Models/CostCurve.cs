namespace LevelManager.Core.Models;

public sealed record CostCurve(
    string Id,
    IReadOnlyList<CostRequirement> Requirements)
{
    public IReadOnlyList<ResourceCost> GetCostRequired(int level)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(level, 1);

        return Requirements
                   .FirstOrDefault(x => x.Level == level)?
                   .Resources 
               ?? [];
    }
}

public sealed record CostRequirement(
    int Level,
    IReadOnlyList<ResourceCost> Resources
);