[System.Serializable]
public class JSONContent
{
    [System.Serializable]
    public class Variant
    {
        public string text;
        public bool correct;
    }

    public string question;
    public Variant[] answers;
    public string background;
}

[System.Serializable]
public struct JSONArray
{
    public JSONContent[] levels;
}