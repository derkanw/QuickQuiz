using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ResultPanel : MonoBehaviour
{
    public Action ResultShown = () => { };

    [SerializeField] private Button NextButton;
    [SerializeField] private Image Background, Icon;
    [SerializeField] private TMP_Text ResultText;
    [SerializeField] private List<Sprite> Sprites;

    private readonly List<string> _strings = new() { "Верно", "Неверно" };
    private readonly List<Color> _colors = new() { Color.green, Color.red };

    public void ShowResult(bool result)
    {
        int index = result ? 0 : 1;
        Icon.sprite = Sprites[index];
        ResultText.text = _strings[index];
        Background.color = _colors[index];
    }

    private void Awake() => NextButton.onClick.AddListener(HideResult);

    private void HideResult()
    {
        ResultShown();
        gameObject.SetActive(false);
    }
}
