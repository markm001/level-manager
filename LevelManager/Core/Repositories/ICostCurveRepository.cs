using LevelManager.Core.Models;

namespace LevelManager.Core.Repositories;

public interface ICostCurveRepository
{
    CostCurve Get(string id);
}