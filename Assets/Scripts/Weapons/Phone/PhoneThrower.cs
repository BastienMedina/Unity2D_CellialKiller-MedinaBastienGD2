using UnityEngine;

public class PhoneThrower : MonoBehaviour
{
    [SerializeField] private GameObject _phonePrefab;
    [SerializeField] private float _throwForce = 10f;

    private Camera _cam;

    void Start() // Récupère la caméra principale
    {
        _cam = Camera.main;
    }

    public void ThrowPhone(Vector2 ScreenPos) // Instancie et lance un téléphone vers la position donnée
    {
        Vector3 worldPos = _cam.ScreenToWorldPoint(ScreenPos);
        worldPos.z = 0f;

        GameObject phone = Instantiate(_phonePrefab, transform.position, Quaternion.identity);

        Vector2 dir = (worldPos - transform.position).normalized;

        phone.GetComponent<Rigidbody2D>().AddForce(dir * _throwForce, ForceMode2D.Impulse); // Applique la force pour lancer le téléphone
    }
}
