using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private QuizPanel Quiz;
    [SerializeField] private ResultPanel Result;

    private int _currentQuestion;
    private JSONController _controller;

    private void Awake()
    {
        Result.gameObject.SetActive(false);
        
        Quiz.ResultChecked += Result.ShowResult;
        Quiz.ResultChecked += ActivateResult;
        Result.ResultShown += GetNextLevel;
    }

    private void Start()
    {
        StaticHolder.QuestionCount = JSONController.content.levels.Length;
        Quiz.GetQuestion(_currentQuestion);
    }

    private void GetNextLevel()
    {
        _currentQuestion++;
        if (_currentQuestion == StaticHolder.QuestionCount)
        {
            SceneManager.LoadScene(StaticHolder.Scenes[ESceneNames.ResultScene]);
            return;
        }
        Quiz.gameObject.SetActive(true);
        Quiz.GetQuestion(_currentQuestion);
    }

    private void ActivateResult(bool result)
    {
        if (result)
            StaticHolder.RightAnswers++;
        Result.gameObject.SetActive(true);
    }
}
