using LevelManager.Core.Validators;

namespace LevelManager.Core.Models;

public sealed record LevelCurve
{
    public string Id { get; }
    public int MaxLevel{ get; }
    public IReadOnlyList<LevelRequirement> Requirements { get; }
    
    public LevelCurve(
        string id,
        int maxLevel,
        IReadOnlyList<LevelRequirement> requirements)
    {
        if (string.IsNullOrWhiteSpace(id)) 
            throw new ArgumentException("Curve ID cannot be empty.", nameof(id));
        
        if (maxLevel < 1)
            throw new ArgumentOutOfRangeException(nameof(maxLevel), "Max level cannot be less than 1.");
        
        ArgumentNullException.ThrowIfNull(requirements);
        LevelCurveValidator.ValidateRequirements(maxLevel, requirements);
        
        Id = id;
        MaxLevel = maxLevel;
        Requirements = requirements;
    }
    
    public int GetExperienceRequired(int level)
    {
        if (level < 1 || level > MaxLevel)
            throw new ArgumentOutOfRangeException(nameof(level), $"Level must be between 1 and {MaxLevel}.");

        if (level == MaxLevel) return 0;

        return Requirements
            .First(x => x.Level == level)
            .ExperienceRequired;
    }
}

public sealed record LevelRequirement(
    int Level,
    int ExperienceRequired
);