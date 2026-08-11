using LevelManager.Core.Models;

namespace TestLevelManager.Core.Model;

[TestClass]
public class TestLevelCurve
{
    [TestMethod]
    public void GetExperienceRequired_ForLevelThree_ReturnsExpRequired()
    {
        var expectedXp = 50;
        
        var levelOne = new LevelRequirement(1, 10);
        var levelTwo = new LevelRequirement(2, 20);
        var levelThree = new LevelRequirement(3, expectedXp);
        var levelFour = new LevelRequirement(4, 180);
        LevelCurve curve = new LevelCurve("TEST", 5, [levelOne, levelTwo, levelThree, levelFour]);

        int actualXpRequired = curve.GetExperienceRequired(3);
        
        Assert.AreEqual(expectedXp, actualXpRequired);
    }
    
    [TestMethod]
    public void GetExperienceRequired_ForMissingLevel_ThrowsException()
    {
        var expectedXp = 50;
        
        var levelOne = new LevelRequirement(1, 10);
        LevelCurve curve = new LevelCurve("TEST", 2, [levelOne]);

        Assert.Throws<ArgumentOutOfRangeException>(
            () =>  curve.GetExperienceRequired(3)    
        );
        
    }
}