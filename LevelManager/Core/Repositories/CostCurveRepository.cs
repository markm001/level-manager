using System.Text.Json;
using LevelManager.Core.Models;
using Utils;

namespace LevelManager.Core.Repositories;

public class CostCurveRepository: ICostCurveRepository
{
    private readonly Dictionary<string, CostCurve> _costCurves;
    
    public CostCurveRepository(IEnumerable<string> curveFiles)
    {
        _costCurves = curveFiles
            .Select(JsonLoader.Load)
            .Select(json => JsonSerializer.Deserialize<CostCurve>(json, DefaultJsonOptions.Default)!)
            .ToDictionary(x => x.Id, x => x);
    }

    public CostCurve Get(string id) => _costCurves[id];
}