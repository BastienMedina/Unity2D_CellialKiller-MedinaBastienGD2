using UnityEngine;

public class ShakeAnimation : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _force;
    [SerializeField] private float _speed;
    private Vector3 _initPos;
    private float _currentTimer;

    void Update() //Appel le timer pour gérer le shake
    {
        Timer();
    }

    void ShakeAnim() //Applique le déplacement de shake
    {
        float posX = Mathf.PerlinNoise(Time.time * _speed, 0f) * 2f - 1f;
        float posY = Mathf.PerlinNoise(0f, Time.time * _speed) * 2f - 1f;
        transform.position = _initPos + new Vector3(posX, posY) * _force;

        if (_currentTimer <= 0f) //Si le timer est fini, remet la position initiale
        {
            transform.position = _initPos;
        }
    }

    void Timer() //Décrémente le timer et applique ShakeAnim si actif
    {
        if (_currentTimer > 0) //Si le timer est actif
        {
            _currentTimer -= Time.deltaTime;
            ShakeAnim();
        }
    }

    public void LaunchShake(float duration, float force, float speed) //Active le shake avec paramètres
    {
        _initPos = transform.position;
        _duration = duration;
        _force = force;
        _speed = speed;
        _currentTimer = duration;
    }
}
