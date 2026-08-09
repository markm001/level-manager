namespace LevelManager.Core.Models;

public sealed record LevelCurve(
    string Id,
    int MaxLevel,
    IReadOnlyList<LevelRequirement> Levels)
{
    public int GetExperienceRequired(int level)
    {
        if (level < 1 || level > MaxLevel)
            throw new ArgumentOutOfRangeException(nameof(level));

        if (level == MaxLevel)
            return 0;

        return Levels
            .First(x => x.Level == level)
            .ExperienceRequired;
    }
}

public sealed record LevelRequirement(
    int Level,
    int ExperienceRequired
);