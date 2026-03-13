using TMPro;
using UnityEngine;

public class TimerScore : MonoBehaviour
{
    [SerializeField] private ScoresCount _score;
    [SerializeField] private int _scoreValue = 1;
    [SerializeField] private int _scoreLimit = 300;
    void Start() //ajoute du score toutes les 3 secondes
    {
        _score.Score = 0;
        InvokeRepeating("AddScore",3f, 3f);
    }

    void AddScore() //Ajoute 1 au score
    {
        _score.Score += _scoreValue;
        if(_score.Score >= _scoreLimit)
        {
            GetComponent<LoadNewScene>().LoadScene();
        }
    }

    public void AddScoreValue()
    {
        _scoreValue++;
    }
}
