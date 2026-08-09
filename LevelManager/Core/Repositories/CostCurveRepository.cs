using System.Text.Json;
using CardManager.Util;
using LevelManager.Core.Models;

namespace LevelManager.Core.Repositories;

public class CostCurveRepository: ICostCurveRepository
{
    private readonly Dictionary<string, CostCurve> _costCurves;
    
    public CostCurveRepository(IEnumerable<string> curveFiles)
    {
        _costCurves = curveFiles
            .Select(JsonLoader.Load)
            .Select(json => JsonSerializer.Deserialize<CostCurve>(json, JsonOptions.Default)!)
            .ToDictionary(x => x.Id, x => x);
    }

    public CostCurve Get(string id) => _costCurves[id];
}