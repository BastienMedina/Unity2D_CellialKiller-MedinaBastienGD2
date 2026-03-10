using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "HighScores", menuName = "Scriptable Objects/HighScores")]
public class HighScores : ScriptableObject
{
    [System.Serializable]
    public class HighScoreEntry
    {
        public string gameName;
        public int highScore;
    }

    public List<HighScoreEntry> highScores = new List<HighScoreEntry>();

    
}
