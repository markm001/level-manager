using System.Text.Json;
using LevelManager.Core.Models;
using Utils;

namespace LevelManager.Core.Repositories;

public class LevelCurveRepository: ILevelCurveRepository
{
    private readonly Dictionary<string, LevelCurve> _lvlCurves;
    
    public LevelCurveRepository(IEnumerable<string> curveFiles)
    {
        _lvlCurves = curveFiles
            .Select(JsonLoader.Load)
            .Select(json => JsonSerializer.Deserialize<LevelCurve>(json, DefaultJsonOptions.Default)!)
            .ToDictionary(x => x.Id, x => x);
    }

    public LevelCurve Get(string id) => _lvlCurves[id];
}