using LevelManager.Core.Models;
using LevelManager.Core.Repositories;

namespace TestLevelManager.Core.Repositories;

[TestClass]
public class TestCostCurveRepository
{
    [TestMethod]
    public void Get_ReturnCostCurve()
    {
        // Arrange
        var repository = new CostCurveRepository(["TestData/DefaultCostCurve.json"]);
        
        // Act
        string curveId = "DEFAULT";
        CostCurve actual = repository.Get(curveId);
            
        // Assert
        Assert.AreEqual(curveId, actual.Id);
        Assert.HasCount(3, actual.Requirements);
    }
}