using UnityEngine;

public class PhoneReceiver : MonoBehaviour
{
    [SerializeField] private ScoresCount _scoreCount;
    [SerializeField] private int _scoreValue;

    private bool _hasPhone = false;
    private ScaleAnimation _scaleAnim;

    public void IngestPhone() //Active l'état du téléphone et l'animation de scale
    {
        _hasPhone = true;
        if (_scaleAnim == null) //Si l'animation n'est pas assignée, récupère le composant
        {
            _scaleAnim = GetComponent<ScaleAnimation>();
            _scaleAnim.ActivateScale();
        }
        _scaleAnim.ActivateScale(); //Relance l'animation de scale
    }

    void Implosion() //Active l'animation d'explosion
    {
        GetComponent<ExplosionAnimation>().ActivateFlipbook(true);
    }

    public void RingPhone() //Vérifie si le téléphone est reçu et applique le score + explosion
    {
        if (_hasPhone) //Si le téléphone a été ingéré
        {
            _scoreCount.Score += _scoreValue;
            Implosion();
        }
    }
}
