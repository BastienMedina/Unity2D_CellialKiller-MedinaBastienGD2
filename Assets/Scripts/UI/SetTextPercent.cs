using TMPro;
using UnityEngine;

public class SetTextPercent : MonoBehaviour
{
    [SerializeField] private ScoresCount _score;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private SetProgressBar _progressBar;

    private int percent;

    void SetText()
    {
        int max = _progressBar.GetGoal();
        _text.text = $"{_score.Score} / {max}";
    }

    void Update()
    {
        SetText();
    }
}
