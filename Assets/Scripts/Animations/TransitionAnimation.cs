using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionAnimation : MonoBehaviour
{
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _startRadius = 1.5f;
    private Material _material;
    private float _timer;

    private void Awake() //Initialise le material et le radius
    {
        Image img = GetComponent<Image>();
        _material = new Material(img.material);
        img.material = _material;
        _material.SetFloat("_Radius", _startRadius);
    }

    private void Update() //Fait l'animation de transition
    {
        _timer += Time.deltaTime;
        float t = _timer / _duration;
        float radius = Mathf.Lerp(_startRadius, 0f, t);
        _material.SetFloat("_Radius", radius);

        if (t >= 1f) //Si l'animation est terminée, charge la scène
        {
            
        }
    }

}
