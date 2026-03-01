using UnityEngine;

public class Phone : MonoBehaviour
{
    [SerializeField] private float _lifeDuration = 1.5f;

    private float _currentTimer = 0f;

    void Timer() //Incrémente le timer et détruit l'objet si sa durée est écoulée
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= _lifeDuration) //Si le téléphone a dépassé sa durée de vie
        {
            Destroy(gameObject);
        }
    }

    void Update() //Appelle le timer à chaque frame
    {
        Timer();
    }

    void OnTriggerEnter2D(Collider2D collider) //Détecte la collision avec un PhoneReceiver
    {
        PhoneReceiver enemy = collider.gameObject.GetComponent<PhoneReceiver>();
        if (enemy != null) //Si le collider a un PhoneReceiver
        {
            enemy.IngestPhone(); //Transfère le téléphone au PhoneReceiver
            Destroy(gameObject); 
        }
    }
}
