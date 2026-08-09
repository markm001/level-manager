using LevelManager.Core.Models;

namespace LevelManager.Core.Providers;

public interface IProgressionCostProvider
{
    IReadOnlyList<ResourceCost> GetCost(LevelProgress progress);
}