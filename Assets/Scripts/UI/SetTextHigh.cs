using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetTextHigh : MonoBehaviour
{
    [SerializeField] private HighScores _highScores;
    [SerializeField] private VerticalLayoutGroup _vertBox;
    [SerializeField] private GameObject _text;

    void Start()
    {
        SetText();
    }

    void SetText()
    {
        foreach(var data in _highScores.highScores)
        {
            string _textHigh = $"{data.gameName} : {data.highScore}";
            GameObject obj = Instantiate(_text, _vertBox.transform);
            obj.GetComponent<TextMeshProUGUI>().text = _textHigh;
        }
    }
}
