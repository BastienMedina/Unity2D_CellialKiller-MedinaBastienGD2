using UnityEngine;

public class SpawnerSurvivor : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 3f;
    [SerializeField] private int _maxEnnemies = 5;
    [SerializeField] private GameObject[] _enemiesPrefabs;

    private int _spawnCount = 0;
    private BoxCollider2D _zone;

    private int _upgradeCount = 0;
    private int _spawnableEnemy = 0;

    void Start()
    {
        _zone = GetComponent<BoxCollider2D>();
        if (_zone != null)
        {
            InvokeRepeating("SpawnEnemies", _spawnRate, _spawnRate);
        }
    }

    void SpawnEnemies()
    {
        Bounds bounds = _zone.bounds;
        if (_spawnCount < _maxEnnemies)
        {
            _spawnCount++;
            int randId = Random.Range(0, _spawnableEnemy);
            GameObject obj = _enemiesPrefabs[randId];
            Vector2 randomPos = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y)); //Position aléatoire dans la zone
            Instantiate(obj, randomPos, Quaternion.identity); //Spawn l'ennemi à cette position
        }
        else
        {
            UpdateDifficulty();
        }
    }

    void UpdateDifficulty()
    {
        if (_spawnRate > 1f)
        {
            _spawnRate -= 0.15f;
            _maxEnnemies += _maxEnnemies / 2;
            _upgradeCount++;
            if (_upgradeCount >= 3 && _spawnableEnemy < _enemiesPrefabs.Length)
            {
                _spawnableEnemy++;
            }
            CancelInvoke("SpawnEnemies");
            InvokeRepeating("SpawnEnemies", _spawnRate, _spawnRate);
            Debug.Log("Upgrade difficulty");
        }
    }

    public void RemoveSpawnCount()
    {
        _spawnCount -= 1;
    }
}
