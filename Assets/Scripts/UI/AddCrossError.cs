using UnityEngine;

public class AddCrossError : MonoBehaviour
{
    [SerializeField] private Transform _errorContainer;
    [SerializeField] private GameObject _crossPrefab;
    [SerializeField] private int _maxErrors = 3;

    private int _totalErrors = 0;

    public void AddError() //Ajoute une erreur visuelle ou gère la fin de partie
    {
        _totalErrors++;
        Instantiate(_crossPrefab, _errorContainer); //Ajoute une croix

        if (_totalErrors >= _maxErrors) //Si le nombre d'erreurs n'a pas atteint le maximum
        {
            GetComponent<LoadNewScene>().LoadScene(); 
        }
    }

}
