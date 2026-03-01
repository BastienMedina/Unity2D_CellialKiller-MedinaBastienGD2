using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    public void Move(Vector3 dir) //Déplace le joueur dans la direction donnée
    {
        transform.position += dir * _speed * Time.deltaTime;
    }
}
