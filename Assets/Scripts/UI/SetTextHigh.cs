using UnityEngine;
using TMPro;

public class SetTextHigh : MonoBehaviour
{
    [SerializeField] private string _text;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private ScoresCount _scoreType;
    [SerializeField] private BestCounts _highScore;

    void SetText() //Affiche le meilleur score correspondant au type de score
    {
        if (_highScore.scores.ContainsKey(_scoreType.name)) //Si le type de score existe dans le dictionnaire
        {
            _textMesh.text = _text + _highScore.scores[_scoreType.name]; //Affiche le meilleur score
        }
        else 
        {
            _textMesh.text = _text + "#"; //Affiche un placeholder
        }
    }

    void Start() //Initialise le texte du meilleur score au démarrage
    {
        SetText();
    }
}
