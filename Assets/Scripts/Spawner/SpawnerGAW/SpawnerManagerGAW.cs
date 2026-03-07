using UnityEngine;

public class SpawnerManagerGAW : MonoBehaviour
{
    [SerializeField] private int _maxClient;
    [SerializeField] private GameObject[] _spawnPointList;
    [SerializeField] private float _spawnRate = 3.5f;
    [SerializeField] private float _badRate = 0.2f;

    private int _clientCount = 0;
    private int _lastID = 0;
    private int _spawnCount = 0;

    private float _currentTimer;

    private SetMaxClientCount _SetMaxClient;

    void Start() //Récupère le composant qui définit le max de clients
    {
        _SetMaxClient = GetComponent<SetMaxClientCount>();
    }

    void Update() //Gère le spawn et la fin de la partie
    {
        if (_SetMaxClient == null) //Si le composant max client n'est pas trouvé, ne fait rien
        {
            return;
        }
        _maxClient = _SetMaxClient.SetMax();

        if (_spawnCount >= _maxClient) //Si on a spawné tous les clients max
        {
            for (int i = 0; i < _spawnPointList.Length; i++)
            {
                Destroy(_spawnPointList[i]); //Détruit tous les points de spawn
            }
            GetComponent<LoadNewScene>().LoadScene(); //Charge la nouvelle scène
            Destroy(gameObject); //Détruit ce manager
        }

        SpawnInRandom(); //Appelle le spawn aléatoire
    }

    public void UpdateClientCount(bool state) //Met à jour le nombre de clients présents
    {
        if (state) //Si client ajouté
        {
            _clientCount++;
        }
        else //Si client retiré
        {
            _clientCount--;
        }
    }

    int RandomID() //Retourne un ID de spawn aléatoire différent du dernier
    {
        int id = 0;
        while (id == _lastID) //Répète jusqu'à avoir un ID différent
        {
            id = Random.Range(0, _spawnPointList.Length);
        }
        _lastID = id;
        return id;
    }

    void SpawnInRandom() //Gère le spawn périodique
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= _spawnRate) //Si le timer atteint le rate
        {
            _currentTimer = 0;
            int newID = RandomID();
            bool randType = RandomType(_badRate);
            _spawnCount++;

            if (randType) //Si c'est un client erreur
            {
                _spawnPointList[newID].GetComponent<SpawnerGAW>().SpawnError();
                IncreaseErrorRate(); //Augmente la chance d'erreur
            }
            else //Si c'est un client normal
            {
                _spawnPointList[newID].GetComponent<SpawnerGAW>().SpawnClient();
            }

            IncreaseSpawnRate(); //Peut diminuer le rate si besoin
        }
    }

    void IncreaseSpawnRate() //Augmente la fréquence de spawn
    {
        _clientCount++;
        if (_clientCount >= 3) //Toutes les 3 additions
        {
            if (_spawnRate > 0) //Si le spawn rate est positif
            {
                _spawnRate -= 0.1f; //Réduit le spawn rate
            }
            _clientCount = 0; //Réinitialise le compteur
        }
    }

    void IncreaseErrorRate() //Augmente la chance de spawn erreur
    {
        if (_badRate < 1f) //Si la chance n'a pas atteint 100%
        {
            _badRate += 0.05f;
        }
    }

    bool RandomType(float chances) //Retourne vrai si spawn erreur selon chance
    {
        float rand = Random.value;
        return rand < chances;
    }
}
