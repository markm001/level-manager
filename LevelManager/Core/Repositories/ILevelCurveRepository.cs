using LevelManager.Core.Models;

namespace LevelManager.Core.Repositories;

public interface ILevelCurveRepository
{
    LevelCurve Get(string id);
}