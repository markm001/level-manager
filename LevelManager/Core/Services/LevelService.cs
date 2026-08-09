using LevelManager.Core.Models;

namespace LevelManager.Core.Services;

public sealed class LevelService : ILevelService
{
    public LevelProgress AddExperience(
        LevelProgress progress,
        LevelCurve curve,
        int experience)
    {
        if (experience < 0)
            throw new ArgumentOutOfRangeException(nameof(experience));

        int level = progress.Level;
        int currentExperience = progress.Experience;

        while (experience > 0 && level < curve.MaxLevel)
        {
            int required = curve.GetExperienceRequired(level);
            int remaining = required - currentExperience;

            if (experience < remaining)
            {
                currentExperience += experience;
                experience = 0;
                break;
            }

            experience -= remaining;
            level++;
            currentExperience = 0;
        }

        return new LevelProgress(level, currentExperience);
    }
}