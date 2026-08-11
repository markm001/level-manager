using LevelManager.Core.Models;

namespace LevelManager.Core.Validators;

public static class CostCurveValidator
{
    public static void ValidateRequirements(
        int maxLevel,
        IReadOnlyList<CostRequirement> requirements)
    {
        if (maxLevel < 1)
            throw new ArgumentOutOfRangeException(nameof(maxLevel));

        ProgressionRequirementValidator.ValidateLevels(
            maxLevel,
            requirements,
            x => x.Level);

        var levels = new HashSet<int>();
        
        foreach (var requirement in requirements)
        {
            if (!levels.Add(requirement.Level))
            {
                throw new ArgumentException(
                    $"Level '{requirement.Level}' cannot be declared more than once.");
            }
            
            ValidateResources(requirement);
        }
    }
    
    private static void ValidateResources(
        CostRequirement requirement)
    {
        var resourceIds = new HashSet<string>();

        foreach (var resource in requirement.Resources)
        {
            if (string.IsNullOrWhiteSpace(resource.ResourceId))
            {
                throw new ArgumentException(
                    $"Resource ID cannot be empty " +
                    $"for level {requirement.Level}.");
            }

            if (resource.Amount <= 0)
            {
                throw new ArgumentException(
                    $"Resource '{resource.ResourceId}' " +
                    $"must have an amount greater than zero " +
                    $"for level {requirement.Level}.");
            }

            if (!resourceIds.Add(resource.ResourceId))
            {
                throw new ArgumentException(
                    $"Resource '{resource.ResourceId}' " +
                    $"is declared more than once for level " +
                    $"{requirement.Level}.");
            }
        }
    }
}