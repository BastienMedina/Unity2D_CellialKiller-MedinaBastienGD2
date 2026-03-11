using UnityEngine;

public class PhoneThrower : MonoBehaviour
{
    [SerializeField] private GameObject _phonePrefab;
    [SerializeField] private float _throwForce = 10f;
    [SerializeField] private int _phoneStock = 3;
    [SerializeField] private int _maxPhoneStock = 3;

    private Camera _cam;

    void Start() // R�cup�re la cam�ra principale
    {
        _cam = Camera.main;
    }

    public void ThrowPhone(Vector2 ScreenPos) // Instancie et lance un t�l�phone vers la position donn�e
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (_phoneStock > 0)
        {
            Vector3 worldPos = _cam.ScreenToWorldPoint(ScreenPos);
            worldPos.z = 0f;

            GameObject phone = Instantiate(_phonePrefab, transform.position, Quaternion.identity);

            Vector2 dir = (worldPos - transform.position).normalized;

            phone.GetComponent<Rigidbody2D>().AddForce(dir * _throwForce, ForceMode2D.Impulse); // Applique la force pour lancer le t�l�phone
            _phoneStock--;
        }
        else if (_phoneStock == 0)
        {
            GetComponent<PhoneManager>().RingAllPhone();
            Debug.Log("Explosion");
            _phoneStock--;
        }
    }

    public void IncreasePhoneStock()
    {
        _maxPhoneStock += 2;
        _phoneStock = _maxPhoneStock;
    }

    public int GetMaxPhone()
    {
        return _maxPhoneStock;
    }

    public int GetCurrentPhoneStock()
    {
        return _phoneStock;
    }
}
