using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField] private string _loadScene;
    [SerializeField] private GameObject _exitObject;
    [SerializeField] private GameObject _loadTransition;

    public void LoadScene() //Instancie l'effet de transition avant de charger la scène
    {
        Instantiate(_loadTransition);
        Invoke(nameof(Load), 1f);
    }

    void OnTriggerEnter2D(Collider2D collider) //Vérifie si le joueur touche l'objet exit
    {
        GameObject col = collider.gameObject;

        if (col.name == _exitObject.name) //Si l'objet touché est l'exit, lance le chargement
        {
            LoadScene();
        }
    }

    public void Load() //Charge directement la scène définie
    {
        SceneManager.LoadScene(_loadScene);
    }
}
