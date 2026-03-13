using UnityEngine;

public class SpawnRunner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval = 3f;
    [SerializeField] private BoxCollider2D _spawnArea;

    private int _spawnCount = 0;

    void Start()
    {
        // Lance le spawn en boucle
        InvokeRepeating(nameof(SpawnEnemy), 0f, _spawnInterval);
    }

    void SpawnEnemy()
    {
        // R�cup�re les limites de la box
        Bounds bounds = _spawnArea.bounds;

        // Choisit une position al�atoire dans la box
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

        // Spawn de l'ennemi
        Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
        _spawnCount++;
        if (_spawnCount >= 5 && _spawnInterval > 1)
        {
            _spawnInterval -= 0.3f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<TimerScore>().AddScoreValue();
        }
    }
}
