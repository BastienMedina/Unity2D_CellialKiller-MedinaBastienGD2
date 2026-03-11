using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField] private string _loadScene;
    [SerializeField] private GameObject _exitObject;
    [SerializeField] private GameObject _loadTransition;

    public void LoadScene() //Instancie l'effet de transition avant de charger la sc�ne
    {
        Instantiate(_loadTransition);
        //Time.timeScale = 0.1f;
        Invoke(nameof(Load), 1f);
    }

    void OnTriggerEnter2D(Collider2D collider) //V�rifie si le joueur touche l'objet exit
    {
        GameObject col = collider.gameObject;

        if (col.name == _exitObject.name) //Si l'objet touch� est l'exit, lance le chargement
        {
            Debug.LogWarning("Exit");
            LoadScene();
        }
    }

    public void Load() //Charge directement la sc�ne d�finie
    {
        SceneManager.LoadScene(_loadScene);
    }
}
