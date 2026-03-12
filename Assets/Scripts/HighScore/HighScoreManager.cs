using System;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [System.Serializable]
    private class DataScores
    {
        public string gameName;
        public ScoresCount _score;
    }

    [SerializeField] private DataScores[] _dataScores;
    [SerializeField] private HighScores _highScore;

    void Start()
    {
        SetAllHigh();
    }

    public void SetAllHigh()
    {
        foreach (var data in _dataScores)
        {
            bool found = false;

            foreach (var entry in _highScore.highScores)
            {
                if (entry.gameName == data.gameName)
                {
                    entry.highScore = data._score.Score; // ou ta méthode
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                HighScores.HighScoreEntry newEntry = new HighScores.HighScoreEntry();
                newEntry.gameName = data.gameName;
                newEntry.highScore = data._score.Score;

                _highScore.highScores.Add(newEntry);
            }
        }
    }
}
