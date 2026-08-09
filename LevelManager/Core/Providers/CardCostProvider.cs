using LevelManager.Core.Models;

namespace LevelManager.Core.Providers;

public sealed class CardCostProvider(CostCurve curve) : IProgressionCostProvider
{
    public IReadOnlyList<ResourceCost> GetCost(LevelProgress progress)
    {
        return curve.GetCostRequired(progress.Level);
    }
}