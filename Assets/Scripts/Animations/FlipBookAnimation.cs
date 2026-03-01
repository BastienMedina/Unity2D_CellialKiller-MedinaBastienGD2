using UnityEngine;

public class FlipBookAnimation : MonoBehaviour
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

    void ChangeFrame() //Change de frame selon la direction
    {
        if (_end) //Si on va en arrière
        {
            _frameID--;
            if (_frameID > 1) //Si pas encore revenu au début
            {
                _spriteRend.sprite = _framesList[_frameID];
            }
            else //Si arrivé au début
            {
                _spriteRend.sprite = _framesList[_frameID];
                _end = false;
            }
        }
        else //Si on avance
        {
            _frameID++;
            if (_frameID < _framesList.Length - 1) //Si pas arrivé à la fin
            {
                _spriteRend.sprite = _framesList[_frameID];
            }
            else //Si arrivé à la fin
            {
                _spriteRend.sprite = _framesList[_frameID];
                _end = true;
            }
        }
    }

    void Update() //Gère le timer pour le flipbook
    {
        if (_activated)
        {
            Timer();
        }
    }

    void Timer() //Incrémente le timer et change de frame
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= _frameRate)
        {
            _currentTimer = 0f;
            ChangeFrame();
        }
    }

    public void ActivateFlipbook(bool state) //Active ou désactive le flipbook
    {
        if (state == false)
        {
            _spriteRend.sprite = _framesList[0];
        }
        _activated = state;
    }
}
