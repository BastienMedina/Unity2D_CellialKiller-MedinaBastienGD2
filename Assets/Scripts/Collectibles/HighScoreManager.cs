using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private BestCounts _highScores; //Référence aux meilleurs scores
    [SerializeField] private ScoresCount _score; //Référence au score actuel

    public void SetHigh() //Met à jour les meilleurs scores
    {
        _highScores.AddScore(_score.name, _score.Score);
    }
}
