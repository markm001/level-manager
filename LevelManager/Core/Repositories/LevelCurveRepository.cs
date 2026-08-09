using System.Text.Json;
using CardManager.Util;
using LevelManager.Core.Models;

namespace LevelManager.Core.Repositories;

public class LevelCurveRepository: ILevelCurveRepository
{
    private readonly Dictionary<string, LevelCurve> _lvlCurves;
    
    public LevelCurveRepository(IEnumerable<string> curveFiles)
    {
        _lvlCurves = curveFiles
            .Select(JsonLoader.Load)
            .Select(json => JsonSerializer.Deserialize<LevelCurve>(json, JsonOptions.Default)!)
            .ToDictionary(x => x.Id, x => x);
    }

    public LevelCurve Get(string id) => _lvlCurves[id];
}