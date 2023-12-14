using UnityEngine;
using System.IO;
using System.Text;

public class JSONController
{
    public static readonly JSONArray content;
    private static readonly string _prefix = "{\"levels\":";
    private static readonly string _jsonPath = "Quiz.json";
    static JSONController()
    {
        var jsonText = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, _jsonPath), Encoding.GetEncoding(1251));
        var text = _prefix + jsonText + '}';
        content = JsonUtility.FromJson<JSONArray>(text);
    }
}
