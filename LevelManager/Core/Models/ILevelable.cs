namespace LevelManager.Core.Models;

public interface ILevelable
{
    LevelProgress Progress { get; }
    void ApplyLevelProgress(LevelProgress progress);
}
