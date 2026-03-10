using UnityEngine;
using UnityEngine.UI;

public class SurvivorScoreManager : MonoBehaviour
{
    [SerializeField] private ScoresCount _scoreCount;
    [SerializeField] private Slider _scoreSlider;
    [SerializeField] private CanvasGroup _upgradePanel;

    void Start()
    {
        SetVisibility(false, _upgradePanel);
        SetVisibility(true, _scoreSlider.GetComponent<CanvasGroup>());
    }

    public void OpenUpgrade()
    {
        FindFirstObjectByType<SetUpgradeButton>().SetAllButton();
        SetVisibility(true, _upgradePanel);
        SetVisibility(false, _scoreSlider.GetComponent<CanvasGroup>());
        Time.timeScale = 0f;
        Debug.Log("Upgrades");
    }

    public void SetVisibility(bool visible, CanvasGroup item)
    {
        if (visible)
        {
            item.alpha = 1f;
            item.interactable = true;
            item.blocksRaycasts = true;
        }
        else
        {
            item.alpha = 0f;
            item.interactable = false;
            item.blocksRaycasts = false;
        }
    }

    public void RemoveUpgrades()
    {
        SetVisibility(false, _upgradePanel);
        SetVisibility(true, _scoreSlider.GetComponent<CanvasGroup>());
        Time.timeScale = 1f;
    }
}
