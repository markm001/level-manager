using LevelManager.Core.Models;
using LevelManager.Core.Validators;

namespace TestLevelManager.Core.Validators;

[TestClass]
public class TestCostCurveValidator
{
    [TestMethod]
    public void ValidateRequirements_InputValid()
    {
        var res = new ResourceCost("GOLD", 10);
        var one = new CostRequirement(1, [res]);
        var two = new CostRequirement(2, [res]);
        
        CostCurveValidator.ValidateRequirements(3, [one, two]);
    }
    
    [TestMethod]
    public void ValidateRequirements_ResourceIdIsEmpty_ThrowsException()
    {
        var res = new ResourceCost("", 10);
        var one = new CostRequirement(1, [res]);

        Assert.Throws<ArgumentException>(
            () => CostCurveValidator.ValidateRequirements(2, [one])
        );
    }
    
    [TestMethod]
    public void ValidateRequirements_ResourceAmountIsZero_ThrowsException()
    {
        var res = new ResourceCost("GOLD", 0);
        var one = new CostRequirement(1, [res]);

        Assert.Throws<ArgumentException>(
            () => CostCurveValidator.ValidateRequirements(2, [one])
        );
    }
    
    [TestMethod]
    public void ValidateRequirements_ResourceDeclaredTwice_ThrowsException()
    {
        var res = new ResourceCost("GOLD", 10);
        var one = new CostRequirement(1, [res, res]);

        Assert.Throws<ArgumentException>(
            () => CostCurveValidator.ValidateRequirements(2, [one])
        );
    }
    
    [TestMethod]
    public void ValidateRequirements_LevelRequirementDeclaredTwice_ThrowsException()
    {
        var res = new ResourceCost("GOLD", 10);
        var one = new CostRequirement(1, [res]);

        Assert.Throws<ArgumentException>(
            () => CostCurveValidator.ValidateRequirements(2, [one,one])
        );
    }

    [TestMethod]
    public void ValidateRequirements_RequirementsCountNotMatched_ThrowsException()
    {
        var res = new ResourceCost("GOLD", 10);
        var one = new CostRequirement(1, [res]);

        Assert.Throws<ArgumentException>(
            () => CostCurveValidator.ValidateRequirements(3, [one])
        );
    }
    
    [TestMethod]
    public void ValidateRequirements_CostRequirementLevelMinusOne_ThrowsException()
    {
        var res = new ResourceCost("GOLD", 10);
        var one = new CostRequirement(-1, [res]);

        Assert.Throws<ArgumentException>(
            () => CostCurveValidator.ValidateRequirements(2, [one])
        );
    }
    
    [TestMethod]
    public void ValidateRequirements_MaxLevelMinusOne_ThrowsException()
    {
        var res = new ResourceCost("GOLD", 10);
        var one = new CostRequirement(1, [res]);

        Assert.Throws<ArgumentOutOfRangeException>(
            () => CostCurveValidator.ValidateRequirements(-1, [one])
        );
    }
}