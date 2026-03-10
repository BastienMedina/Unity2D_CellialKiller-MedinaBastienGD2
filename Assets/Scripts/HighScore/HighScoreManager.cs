using System;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [System.Serializable]
    private class DataScores
    {
        [SerializeField] private string gameName;
        [SerializeField] private ScoresCount _score;
    }

    [SerializeField] private DataScores _dataScores;
    [SerializeField] private HighScores _highScore;
    public void SetAllHigh()
    {
        
    }
}
