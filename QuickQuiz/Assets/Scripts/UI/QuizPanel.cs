using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class QuizPanel : MonoBehaviour
{
    public Action<bool> ResultChecked = (bool result) => { };

    [SerializeField] private TMP_Text Question;
    [SerializeField] private Image Background;
    [SerializeField] private GameObject AnswersField;
    [SerializeField] private GameObject AnswerPrefab;

    private JSONContent _currentQuestion;

    public void GetQuestion(int number)
    {
        _currentQuestion = JSONController.content.levels[number];
        Background.sprite = LoadBackground();
        Question.text = string.Concat(number + 1, " вопрос.\n", _currentQuestion.question);

        for (int count = 0; count < _currentQuestion.answers.Length; count++)
        {
            var answer = Instantiate(AnswerPrefab, AnswersField.transform);
            var answerText = _currentQuestion.answers[count].text;
            var answerNumber = answer.transform.GetChild(0).GetComponent<TMP_Text>();
            var answerButton = answer.GetComponent<Button>();

            answerNumber.text = (count + 1).ToString();
            answer.transform.GetChild(1).GetComponent<TMP_Text>().text = answerText;
            answerButton.onClick.AddListener(() => CheckAnswer(answerNumber.text));
        }
    }

    public void CheckAnswer(string answer)
    {
        ResultChecked(_currentQuestion.answers[int.Parse(answer) - 1].correct);
        ClearAnswers();
        gameObject.SetActive(false);
    }

    private Sprite LoadBackground()
    {
        var path = _currentQuestion.background;
        return Resources.Load<Sprite>(path.Split('.')[0]); ;
    }

    private void ClearAnswers()
    {
        for (int count = 0; count < AnswersField.transform.childCount; count++)
            Destroy(AnswersField.transform.GetChild(count).gameObject);
    }
}