namespace CardManager.Util;

public static class JsonLoader
{
    public static string Load(string path)
    {
        using var reader = new StreamReader(path);
        return reader.ReadToEnd();
    }

    public static IEnumerable<string> LoadAll(string directory)
    {
        foreach (string file in Directory.EnumerateFiles(directory, "*.json"))
        {
            yield return Load(file);
        }
    }
}