using LevelManager.Core.Models;

namespace LevelManager.Core.Services;

public interface ILevelService
{
    LevelProgress AddExperience(LevelProgress progress, LevelCurve curve, int experience);
}