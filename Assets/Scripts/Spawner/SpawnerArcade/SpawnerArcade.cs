using UnityEngine;

public class SpawnerArcade : MonoBehaviour
{
    [System.Serializable]
    private class SpawnData
    {
        public GameObject prefab;
        public int min;
        public int max;
    }

    [SerializeField] private SpawnData[] _spawnEnemiesData;

    private BoxCollider2D _zone;

    void Start() //Récupère la zone de spawn et lance l'initialisation du spawn
    {
        _zone = GetComponent<BoxCollider2D>();
        InitiateSpawn();
    }

    void InitiateSpawn() //Fait spawn les ennemis aléatoirement dans la zone
    {
        Bounds bounds = _zone.bounds;

        foreach (var data in _spawnEnemiesData)
        {
            int amount = Random.Range(data.min, data.max + 1); //Détermine le nombre d'ennemis à spawn
            for (int i = 0; i < amount; i++)
            {
                Vector2 randomPos = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y)); //Position aléatoire dans la zone
                Instantiate(data.prefab, randomPos, Quaternion.identity); //Spawn l'ennemi à cette position
            }
        }
    }
}
