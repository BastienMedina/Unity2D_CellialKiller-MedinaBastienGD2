using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    [SerializeField] private float _frameRate = 0.5f;
    [SerializeField] private Sprite[] _framesList;
    [SerializeField] private bool _activated = false;

    private SpriteRenderer _spriteRend;
    private bool _end = false;
    private int _frameID = 0;
    private float _currentTimer;

    void Start() //Récupère le sprite renderer
    {
        _spriteRend = GetComponent<SpriteRenderer>();
    }

    void ChangeFrame() //Change de frame et détruit si fin
    {
        if (_end)
        {
            _frameID--;
            if (_frameID > 1)
            {
                _spriteRend.sprite = _framesList[_frameID];
            }
            else
            {
                _spriteRend.sprite = _framesList[_frameID];
                _end = false;
            }
        }
        else
        {
            _frameID++;
            if (_frameID < _framesList.Length - 1)
            {
                _spriteRend.sprite = _framesList[_frameID];
            }
            else
            {
                _spriteRend.sprite = _framesList[_frameID];
                _end = true;
                Destroy(gameObject); //Détruit l'objet à la fin de l'explosion
            }
        }
    }

    void Update() //Gère le timer pour l'animation
    {
        if (_activated)
        {
            Timer();
        }
    }

    void Timer() //Incrémente timer et change frame
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= _frameRate)
        {
            _currentTimer = 0f;
            ChangeFrame();
        }
    }

    public void ActivateFlipbook(bool state) //Active/désactive l'animation
    {
        if (state == false)
        {
            _spriteRend.sprite = _framesList[0];
        }
        _activated = state;
    }
}
