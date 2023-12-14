using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private Button RestartButton;
    [SerializeField] private TMP_Text TextField;

    private void Awake()
    {
        RestartButton.onClick.AddListener(RestartGame);
        GetResult();
    }

    private void RestartGame()
    {
        StaticHolder.RightAnswers = 0;
        StaticHolder.QuestionCount = 0;
        SceneManager.LoadScene(StaticHolder.Scenes[ESceneNames.MainMenu]);
    }

    private void GetResult()
    {
        Color color = (float)StaticHolder.RightAnswers / StaticHolder.QuestionCount >= 0.5 ? Color.green : Color.red;
        TextField.text = string.Join(' ', StaticHolder.RightAnswers, "из", StaticHolder.QuestionCount);
        TextField.color = color;
    }
}