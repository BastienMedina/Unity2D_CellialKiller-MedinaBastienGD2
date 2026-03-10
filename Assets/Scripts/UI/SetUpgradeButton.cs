using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.Events;

public class SetUpgradeButton : MonoBehaviour
{
    [System.Serializable]
    private class ButtonData
    {
        public Button bouton;
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI descText;
    }

    [System.Serializable]
    private class UpgradeData
    {
        public UnityEvent upgradeAction;
        public string upgradeTitle;
        public string upgradeDesc;
    }

    [SerializeField] private UpgradeData[] upgData;
    [SerializeField] private ButtonData[] btnData;
    [SerializeField] private SurvivorScoreManager _scoreManager;

    private int[] _randomUpg;
    private List<int> _randUpg = new List<int>();

    void Start()
    {
        
    }

    public void SetAllButton()
    {
        ChooseRandomUpgrade();
        int id = 0;
        foreach (var data in btnData)
        {
            int upgId = _randUpg[id];
            data.titleText.text = upgData[upgId].upgradeTitle;
            data.descText.text = upgData[upgId].upgradeDesc;
            data.bouton.onClick.RemoveAllListeners();
            data.bouton.onClick.AddListener(() => upgData[upgId].upgradeAction?.Invoke());
            data.bouton.onClick.AddListener(ReplayGame);
        }
    }

    void ChooseRandomUpgrade()
    {
        _randUpg.Clear();
        for (int i = 0; i < btnData.Length; i++)
        {
            while (true)
            {
                int randId = UnityEngine.Random.Range(0, upgData.Length);
                if (!_randUpg.Contains(randId))
                {
                    _randUpg.Add(randId);
                    break;
                }
            }
        }
    }

    public void ReplayGame()
    {
        _scoreManager.RemoveUpgrades();
    }
}
