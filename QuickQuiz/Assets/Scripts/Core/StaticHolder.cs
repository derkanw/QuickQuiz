using System.Collections.Generic;

public static class StaticHolder
{
    public static int QuestionCount, RightAnswers;
    public readonly static Dictionary<ESceneNames, string> Scenes = new()
    {
        { ESceneNames.MainMenu, "MainMenu" },
        { ESceneNames.LevelScene, "Level" },
        { ESceneNames.ResultScene, "Result" }
    };
}
