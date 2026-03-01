using UnityEngine;

public class ClienrArcade : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Transform _exitPoint;

    void Update() // Appelle Exit pour déplacement
    {
        Exit();
    }

    void Exit() // Déplace vers le point de sortie
    {
        if (_exitPoint != null) // Si le point de sortie existe
        {
            transform.position = Vector2.MoveTowards(transform.position, _exitPoint.position, _speed * Time.deltaTime);
        }
        else
        {
            _exitPoint = GameObject.FindWithTag("ExitAI").transform;
        }
    }
}
