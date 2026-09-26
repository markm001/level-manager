using LevelManager.Core.Models;

namespace TestLevelManager.Core.Model;

[TestClass]
public class TestCostCurve
{
    [TestMethod]
    public void GetResourcesRequired_ForLevelOne_ReturnsResourcesRequired()
    {
        string resourceId = "SHARD_BLUE";
        string goldId = "GOLD";

        int resourceAmount = 10;
        int goldAmount = 200;

        ResourceCost resource = new ResourceCost(resourceId, resourceAmount);
        ResourceCost gold = new ResourceCost(goldId, goldAmount);
        
        var levelOne = new CostRequirement(1, [resource, gold]);
        var levelTwo = new CostRequirement(2, [resource, gold]);
        
        CostCurve curve = new CostCurve("TEST",[levelOne, levelTwo]);

        IReadOnlyList<ResourceCost> actualCost = curve.GetCostRequired(1);

        Assert.AreEqual(resourceId, actualCost[0].ResourceId);
        Assert.AreEqual(resourceAmount, actualCost[0].Amount);
        
        Assert.AreEqual(goldId, actualCost[1].ResourceId);
        Assert.AreEqual(goldAmount, actualCost[1].Amount);
    }
    
    [TestMethod]
    public void GetResourcesRequired_ForNegativeLevel_ThrowsException()
    {
        
        var levelOne = new CostRequirement(1, []);
        
        CostCurve curve = new CostCurve("TEST",[levelOne]);

        Assert.Throws<ArgumentOutOfRangeException>(
            () => curve.GetCostRequired(-1)
        );
    }
    
    [TestMethod]
    public void GetCostRequired_ForMissingLevel_ReturnsEmpty()
    {
        var levelOne = new CostRequirement(
            1, [new ResourceCost("GOLD", 100)]
            );

        var curve = new CostCurve(
            "TEST",
            [levelOne]);

        var actual = curve.GetCostRequired(2);

        Assert.IsEmpty(actual);
    }
}