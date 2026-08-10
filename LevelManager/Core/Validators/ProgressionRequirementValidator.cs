namespace LevelManager.Core.Validators;

public static class ProgressionRequirementValidator
{
    public static void ValidateLevels<T>(
        int maxLevel,
        IReadOnlyList<T> requirements,
        Func<T, int> getLevel)
    {
        ArgumentNullException.ThrowIfNull(requirements);

        var expectedLevels = Enumerable
            .Range(1, maxLevel - 1)
            .ToHashSet();

        var actualLevels = requirements
            .Select(getLevel)
            .ToHashSet();

        if (!expectedLevels.SetEquals(actualLevels))
        {
            throw new ArgumentException(
                "Requirements must contain exactly one " +
                "requirement for every level from 1 to MaxLevel - 1.",
                nameof(requirements));
        }
    }
}