using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    void Update() //Appelle l'animation de rotation
    {
        RotationAnim();
    }

    void RotationAnim() //Applique rotation continue
    {
        transform.Rotate(0f, 0f, _speed * Time.deltaTime);
    }
}
