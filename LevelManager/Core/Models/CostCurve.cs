namespace LevelManager.Core.Models;

public sealed record CostCurve(
    string Id,
    IReadOnlyList<CostRequirement> Requirements)
{
    public IReadOnlyList<ResourceCost> GetCostRequired(int level)
    {
        return Requirements
            .First(x => x.Level == level)
            .Resources;
    }
}

public sealed record CostRequirement(
    int Level,
    IReadOnlyList<ResourceCost> Resources
);