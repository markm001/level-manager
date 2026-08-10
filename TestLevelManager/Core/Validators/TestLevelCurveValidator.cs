using LevelManager.Core.Models;
using LevelManager.Core.Validators;

namespace TestLevelManager.Core.Validators;

[TestClass]
public class TestLevelCurveValidator
{
    [TestMethod]
    public void ValidateRequirements_InputValid()
    {
        var one = new LevelRequirement(1, 50);
        var two = new LevelRequirement(2, 100);
        var three = new LevelRequirement(3, 200);
        
        LevelCurveValidator.ValidateRequirements(4, [one, two, three]);
    }
    
    [TestMethod]
    public void ValidateRequirements_MaxLevelMinusOne_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => LevelCurveValidator.ValidateRequirements(-1, [])
        );
    }
    
    [TestMethod]
    public void ValidateRequirements_RequirementsCountNotMatched_ThrowsException()
    {
        // Arrange
        var one = new LevelRequirement(1, 100);
        
        // Assert
        Assert.Throws<ArgumentException>(
            () => LevelCurveValidator.ValidateRequirements(3, [one])
        );
    }

    [TestMethod]
    public void ValidateRequirements_RequirementsLevelsNotMatched_ThrowsException()
    {
        // Arrange
        var one = new LevelRequirement(1, 100);
        var three = new LevelRequirement(3, 200);
        
        // Assert
        Assert.Throws<ArgumentException>(
            () => LevelCurveValidator.ValidateRequirements(3, [one, three])
        );
    }
    
    [TestMethod]
    public void ValidateRequirements_ExpIsZero_ThrowsException()
    {
        // Arrange
        var one = new LevelRequirement(1, 100);
        var two = new LevelRequirement(2, 0);
        
        // Assert
        Assert.Throws<ArgumentException>(
            () => LevelCurveValidator.ValidateRequirements(3, [one, two])
        );
    }
}