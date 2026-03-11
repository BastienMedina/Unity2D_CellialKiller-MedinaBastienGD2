using UnityEngine;
using UnityEngine.UI;

public class SetProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _scoreSlider;
    [SerializeField] private ScoresCount _scoreCount;
    [SerializeField] private int _goal = 5;
    [SerializeField] private SurvivorScoreManager _scoreManager;

    private bool _inUpgrade = false;

    void Start()
    {
        _scoreSlider.minValue = 0;
        _scoreSlider.maxValue = _goal;
    }

    void Update()
    {
        SetPercent();
    }

    void SetPercent()
    {
        _scoreSlider.value = _scoreCount.Score;
        if (_scoreCount.Score >= _goal && _inUpgrade == false)
        {
            _inUpgrade = true;
            UpgradeGoal();
            _scoreManager.OpenUpgrade();
        }
    }

    public void UpgradeGoal()
    {
        _scoreSlider.minValue = _goal;
        int newGoal = _goal + _goal / 2;
        _scoreSlider.maxValue = newGoal;
        _goal = newGoal;
    }

    public void SetInUpgrade()
    {
        _inUpgrade = false;
        Debug.Log("min :" + _scoreSlider.minValue);
        Debug.Log("max :" + _scoreSlider.maxValue);
    }

    public int GetGoal()
    {
        return _goal;
    }
}
