using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    private ShakeAnimation _cameraShake;

    public void RingAllPhone() //Fait sonner tous les téléphones et détruit les objets Phone
    {
        PhoneReceiver[] enemies = Object.FindObjectsByType<PhoneReceiver>(FindObjectsSortMode.None);
        Phone[] phones = Object.FindObjectsByType<Phone>(FindObjectsSortMode.None);
        foreach (PhoneReceiver enemy in enemies) //Parcourt tous les PhoneReceiver
        {
            enemy.RingPhone(); //Fait sonner chaque téléphone
        }

        foreach (Phone phone in phones) //Parcourt tous les Phone
        {
            Destroy(phone.gameObject); //Détruit les téléphones
        }

        if (_cameraShake == null) //Si l'animation de shake n'est pas assignée, récupère-la
        {
            _cameraShake = GameObject.FindWithTag("MainCamera").GetComponent<ShakeAnimation>();
        }
        _cameraShake.LaunchShake(0.2f, 0.15f, 25f); //Lance le shake de la caméra
    }
}
