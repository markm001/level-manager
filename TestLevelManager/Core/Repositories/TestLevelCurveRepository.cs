using LevelManager.Core.Models;
using LevelManager.Core.Repositories;

namespace TestLevelManager.Core.Repositories;

[TestClass]
public class TestLevelCurveRepository
{
    [TestMethod]
    public void Get_ReturnLevelCurve()
    {
        // Arrange
        var repository = new LevelCurveRepository(["TestData/DefaultLevelCurve.json"]);
        
        // Act
        string curveId = "DEFAULT";
        LevelCurve actual = repository.Get(curveId);
            
        // Assert
        Assert.AreEqual(curveId, actual.Id);
        Assert.AreEqual(5, actual.MaxLevel);
        Assert.HasCount(4, actual.Requirements);
    }
}