using UnityEngine;

public class PlayerArcade : MonoBehaviour
{
    [SerializeField] private int _hp = 6;
    [SerializeField] private int _maxHp = 6;
    [SerializeField] private GameObject _lifebar;
    
    void Start() //Initialise la vie du joueur au max
    {
        _hp = _maxHp;
        _lifebar.GetComponent<SetPlayerHealthbar>().SetAllHealth();
    }

    public void TakeDamages(int damages) //Applique des dégâts au joueur
    {
        _hp -= damages;
        _lifebar.GetComponent<SetPlayerHealthbar>().RemoveHeart(damages);
        GameObject.Find("Main Camera").GetComponent<ShakeAnimation>().LaunchShake(0.2f, 0.15f, 25f);
        if (_hp <= 0) //Si la vie tombe à 0 ou moins
        {
            Die(); //Le joueur meurt
        }
    }

    void Die() //Charge la scène de mort ou de fin
    {
        GetComponent<LoadNewScene>().LoadScene();
    }

    public void RestoreLife()
    {
        _hp = _maxHp;
    }

    public void IncreaseMaxLife()
    {
        _maxHp += 1;
    }

    public int GetMaxHp()
    {
        return _maxHp;
    }
}
