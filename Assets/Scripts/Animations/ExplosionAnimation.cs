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

    void Start() //R�cup�re le sprite renderer
    {
        _spriteRend = GetComponent<SpriteRenderer>();
    }

    void ChangeFrame() //Change de frame et d�truit si fin
    {
        if (_end)
    {
        _frameID--;
        if (_frameID < 0)
        {
            _frameID = 0;
            _end = false;
        }
    }
    else
    {
        _frameID++;
        if (_frameID >= _framesList.Length)
        {
            _frameID = _framesList.Length - 1;
            _end = true;
            Destroy(gameObject);
        }
    }

    _spriteRend.sprite = _framesList[_frameID];
    }

    void Update() //G�re le timer pour l'animation
    {
        if (_activated)
        {
            Timer();
        }
    }

    void Timer() //Incr�mente timer et change frame
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= _frameRate)
        {
            _currentTimer = 0f;
            ChangeFrame();
        }
    }

    public void ActivateFlipbook(bool state) //Active/d�sactive l'animation
    {
        if (state == false)
        {
            _spriteRend.sprite = _framesList[0];
        }
        _activated = state;
    }
}
