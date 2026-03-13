using System;
using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    

    public void Move(Vector3 dir) //D�place le joueur dans la direction donn�e
    {
        transform.position += dir * _speed * Time.deltaTime;
    }

    public void IncreaseSpeed()
    {
        _speed += 1f;
    }
}
