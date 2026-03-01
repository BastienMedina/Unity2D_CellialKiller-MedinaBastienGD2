using UnityEngine;

public class SellerManager : MonoBehaviour
{
    private int _totalSeller;
    private int _deadSeller;

    public bool NeedFlee() // Retourne vrai si assez de vendeurs sont morts pour fuir
    {
        return _deadSeller >= _totalSeller / 3;
    }

    public void AddDead() // Ajoute un vendeur mort
    {
        _deadSeller++;
    }

    public void SetTotal(int total) // Ajoute au total de vendeurs
    {
        _totalSeller += total;
    }
}
