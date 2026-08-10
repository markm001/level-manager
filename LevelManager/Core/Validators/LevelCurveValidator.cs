using LevelManager.Core.Models;

namespace LevelManager.Core.Validators;

public static class LevelCurveValidator
{
    public static void ValidateRequirements(
        int maxLevel,
        IReadOnlyList<LevelRequirement> requirements)
    {
        if (maxLevel < 1)
            throw new ArgumentOutOfRangeException(nameof(maxLevel));

        ProgressionRequirementValidator.ValidateLevels(
            maxLevel,
            requirements,
            x => x.Level);

        foreach (var requirement in requirements)
        {
            if (requirement.ExperienceRequired <= 0)
            {
                throw new ArgumentException(
                    $"Experience required for level {requirement.Level} must be greater than zero.",
                    nameof(requirements)
                );
            }
        }
    }
}