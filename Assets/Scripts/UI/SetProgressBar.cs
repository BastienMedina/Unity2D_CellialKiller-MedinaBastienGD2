using UnityEngine;
using UnityEngine.UI;

public class SetProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _scoreSlider;
    [SerializeField] private ScoresCount _scoreCount;
    [SerializeField] private int _goal = 5;

    void Update()
    {
        SetPercent();
    }

    void SetPercent()
    {
        _scoreSlider.value = _scoreCount.Score;
        if (_scoreCount.Score >= _goal)
        {
            UpgradeGoal();
            FindFirstObjectByType<SurvivorScoreManager>().OpenUpgrade();
        }
    }

    void UpgradeGoal()
    {
        _scoreSlider.minValue = _goal;
        int newGoal = _goal + _goal / 2;
        _scoreSlider.maxValue = newGoal;
        _goal = newGoal;
    }
}
