using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [Header("Animation presets")]
    [SerializeField] private float _intensity = 0.5f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private bool _doOnce = false;

    private float _initScale;
    private float _maxScale;

    private bool _ended = false;
    private bool _isActive = false;

    void Start()
    {
        _initScale = transform.localScale.x;
        _maxScale = _initScale + _intensity;

        // si on ne veut pas doOnce  animation en continu
        if (!_doOnce)
        {
            _isActive = true;
        }
    }

    void Update()
    {
        if (!_isActive) return;

        ScaleAnim();
    }

    void ScaleAnim()
    {
        if (_ended)
        {
            RemoveScale();
        }
        else
        {
            AddScale();
        }
    }

    void AddScale()
    {
        float newScale = transform.localScale.x + Time.deltaTime * _speed;
        transform.localScale = new Vector3(newScale, newScale, newScale);

        if (newScale >= _maxScale)
        {
            _ended = true;
        }
    }

    void RemoveScale()
    {
        float newScale = transform.localScale.x - Time.deltaTime * _speed;
        transform.localScale = new Vector3(newScale, newScale, newScale);

        if (newScale <= _initScale)
        {
            transform.localScale = new Vector3(_initScale, _initScale, _initScale);
            _ended = false;

            // si mode doOnce  stop après un cycle
            if (_doOnce)
            {
                _isActive = false;
            }
        }
    }

    public void ActivateScale()
    {
        if (!_doOnce) return;

        _initScale = transform.localScale.x;
        _maxScale = _initScale + _intensity;

        _ended = false;
        _isActive = true;
    }

}
