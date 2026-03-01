using UnityEngine;

public class ClientMouvementsGAW : MonoBehaviour
{
    [SerializeField] private Vector3 _target;
    [SerializeField] private float _speed = 2f;

    void Update() // Appelle WalkForward pour avancer
    {
        WalkForward();
    }

    void WalkForward() // Fait avancer vers la cible
    {
        if (transform.position.y < _target.y) // Si pas encore arrivé à la cible
        {
            float newY = transform.position.y + _speed * Time.deltaTime;
            Vector3 newPos = new Vector3(transform.position.x, newY, transform.position.z);
            transform.position = newPos;
        }
        else // Si arrivé à la cible
        {
            InTarget();
        }
    }

    public void InstanceClient(Vector3 target) // Définit la position cible du client
    {
        _target = target;
    }

    void InTarget() // Supprime l'objet quand il arrive à la cible
    {
        Destroy(gameObject);
    }
}
