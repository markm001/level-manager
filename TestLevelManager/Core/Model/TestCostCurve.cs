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
    public void GetResourcesRequired_ForMissingLevel_ThrowsException()
    {
        
        var levelOne = new CostRequirement(1, []);
        
        CostCurve curve = new CostCurve("TEST",[levelOne]);

        Assert.Throws<InvalidOperationException>(
            () => curve.GetCostRequired(5)
        );
    }
}