using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [Header("Animation presets")]
    [SerializeField] private float _intensity = 0.5f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _doOnce = false;
    private float _initScale;
    private float _maxScale;
    private bool _ended = false;
    private bool _isActive = false;

    void Update() //Applique l'animation si active
    {
        if (!_isActive) //Si l'animation est inactive, ne fait rien
        {
            return;
        }
        ScaleAnim();
    }

    void ScaleAnim() //Gère l'augmentation et la diminution du scale
    {
        if (_initScale <= 0) //Si le scale initial n'est pas défini
        {
            _initScale = transform.localScale.x;
            _maxScale = _initScale + _intensity;
        }
        else
        {
            if (_ended) //Si l'animation descend
            {
                RemoveScale();
                if (transform.localScale.x <= _initScale) //Si le scale est revenu à l'initial
                {
                    _ended = false;
                }
            }
            else //Si l'animation monte
            {
                AddScale();
                if (transform.localScale.x >= _maxScale) //Si le scale a atteint le max
                {
                    _ended = true;
                }
            }
        }
    }

    void AddScale() //Augmente le scale
    {
        float newScale = transform.localScale.x + Time.deltaTime * _speed;
        Vector3 scaleVec = new Vector3(newScale, newScale, newScale);
        transform.localScale = scaleVec;
    }

    void RemoveScale() //Diminue le scale
    {
        float newScale = transform.localScale.x - Time.deltaTime * _speed;
        Vector3 scaleVec = new Vector3(newScale, newScale, newScale);
        transform.localScale = scaleVec;

        if (transform.localScale.x <= _initScale) //Si retour au scale initial et doOnce activé, désactive animation
        {
            if (_doOnce)
            {
                _isActive = false;
                _ended = false;
            }
        }
    }

    public void ActivateScale() //Active l'animation de scale
    {
        _isActive = true;
    }

}
