using UnityEngine;

public class AddExitClient : MonoBehaviour
{
    [SerializeField] private Counts _exitCount;

    void Start() //Remet le compte de client echapper a 0
    {
        _exitCount.count = 0;
    }

    void OnTriggerEnter2D(Collider2D collider) //Ajoute tout les clients qui traversent exit au count d'exit
    {
        ClienrArcade client = collider.gameObject.GetComponent<ClienrArcade>();
        if (client != null) //Si le compte de client n'est pas référencer, ne fait pas la logique
        {
            _exitCount.count++;
            Destroy(collider.gameObject);
        }
        Debug.Log("Trigger !!");
    }
}
