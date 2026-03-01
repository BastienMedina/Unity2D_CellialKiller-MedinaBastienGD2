using UnityEngine;
using TMPro;

public class SetTextScore : MonoBehaviour
{
    [SerializeField] private string _text;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private ScoresCount _score;

    private int _currentScore = -1;

    void Update() //Met à jour le texte du score si le score a changé
    {
        SetText();
    }

    void SetText() //Vérifie si le score a changé et met à jour le texte affiché
    {
        if (_score.Score != _currentScore) //Si le score actuel est différent du score affiché
        {
            _currentScore = _score.Score;
            _scoreText.text = _text + _currentScore; //Met à jour le texte avec le nouveau score
        }
    }
}
