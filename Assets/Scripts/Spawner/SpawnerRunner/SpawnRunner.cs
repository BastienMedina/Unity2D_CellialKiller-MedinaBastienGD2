using UnityEngine;

public class SpawnRunner : MonoBehaviour
{
    [Header("Spawn Settings")]

    // Prefab de l'ennemi à faire apparaître
    [SerializeField] private GameObject _enemyPrefab;

    // Temps entre chaque spawn
    [SerializeField] private float _spawnInterval = 2f;

    // BoxCollider utilisé comme zone de spawn
    [SerializeField] private BoxCollider2D _spawnArea;

    void Start()
    {
        // Lance le spawn en boucle
        InvokeRepeating(nameof(SpawnEnemy), 0f, _spawnInterval);
    }

    void SpawnEnemy()
    {
        // Récupère les limites de la box
        Bounds bounds = _spawnArea.bounds;

        // Choisit une position aléatoire dans la box
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

        // Spawn de l'ennemi
        Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
    }
}
