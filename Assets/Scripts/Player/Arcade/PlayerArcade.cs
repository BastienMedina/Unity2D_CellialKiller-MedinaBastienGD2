using UnityEngine;

public class PlayerArcade : MonoBehaviour
{
    [SerializeField] private int _hp = 6;
    [SerializeField] private int _maxHp = 6;

    void Start() //Initialise la vie du joueur au max
    {
        _hp = _maxHp;
    }

    public void TakeDamages(int damages) //Applique des dégâts au joueur
    {
        _hp -= damages;
        if (_hp <= 0) //Si la vie tombe à 0 ou moins
        {
            Die(); //Le joueur meurt
        }
    }

    void Die() //Charge la scène de mort ou de fin
    {
        GetComponent<LoadNewScene>().LoadScene();
    }
}
