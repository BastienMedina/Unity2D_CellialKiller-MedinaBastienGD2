using UnityEngine;

public class BreathAnimation : MonoBehaviour
{
    [Header("Animation presets")]
    [SerializeField] private float _recurence = 0.5f;
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private Sprite _frame1;
    [SerializeField] private Sprite _frame2;
    [SerializeField] private bool _isActive = true;

    private bool _initial = true;
    private SpriteRenderer _spriteRend;
    private float _currentTimer = 0f;

    void BreathAnim() //Anime la respiration
    {
        if (_spriteRend != null)
        {
            Timer();
        }
        else //Si sprite renderer pas récupéré
        {
            _spriteRend = GetComponent<SpriteRenderer>();
        }
    }

    void ChangeSprite() //Alterne les sprites
    {
        if (_initial)
        {
            _spriteRend.sprite = _frame2;
            _initial = false;
        }
        else
        {
            _spriteRend.sprite = _frame1;
            _initial = true;
        }
    }

    void Timer() //Gère le timer pour alterner sprite
    {
        _currentTimer += Time.deltaTime * _speed;
        if (_currentTimer >= _recurence)
        {
            _currentTimer = 0f;
            ChangeSprite();
        }
    }

    void Update() //Appelle BreathAnim si actif
    {
        if (_isActive)
        {
            BreathAnim();
        }
    }

    public void ActiveBreath(bool state) //Active/désactive la respiration
    {
        _isActive = state;
    }
}
    
