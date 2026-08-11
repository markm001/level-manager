using LevelManager.Core.Models;
using LevelManager.Core.Services;

namespace TestLevelManager.Core.Services;

[TestClass]
public class TestLevelService
{
    struct TestCard():ILevelable
    {
        public LevelProgress Progress { get; private set; } = new LevelProgress(1, 0);

        public void ApplyLevelProgress(LevelProgress progress)
        {
            Progress = progress;
        }
    }
    
    [TestMethod]
    public void TestAddExperience_AddsExperienceToCard()
    {
        var card = new TestCard();
        
        LevelCurve curve = new LevelCurve("TEST", 4, [
            new LevelRequirement(1, 10),
            new LevelRequirement(2, 50),
            new LevelRequirement(3, 80),
        ]);
        
        LevelService service = new LevelService();
        
        var newProgress = service.AddExperience(
            card.Progress,
            curve,
            5);
        
        card.ApplyLevelProgress(newProgress);
        
        Assert.AreEqual(1, card.Progress.Level);
    }
    
    [TestMethod]
    public void TestAddExperience_OverCap_AddsExperienceToCardStopsAtMaxLevel()
    {
        var card = new TestCard();
        var maxLevel = 3;
        
        LevelCurve curve = new LevelCurve("TEST", maxLevel, [
            new LevelRequirement(1, 10),
            new LevelRequirement(2, 50)
        ]);
        
        LevelService service = new LevelService();
        
        var newProgress = service.AddExperience(
            card.Progress,
            curve,
            125);
        
        card.ApplyLevelProgress(newProgress);
        
        Assert.AreEqual(maxLevel, card.Progress.Level);
    }
    
    [TestMethod]
    public void TestAddExperience_MinusOne_ThrowsException()
    {
        var card = new TestCard();
        var maxLevel = 2;
        
        LevelCurve curve = new LevelCurve("TEST", maxLevel, [
            new LevelRequirement(1, 10)
        ]);
        
        LevelService service = new LevelService();

        Assert.Throws<ArgumentOutOfRangeException>(
            () => service.AddExperience(card.Progress, curve,-1)
        );
    }
    
    
}