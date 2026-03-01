using UnityEngine;

public class SpawnerGAW : MonoBehaviour
{
    [SerializeField] private GameObject _clientPrefab;
    [SerializeField] private GameObject _errorPrefab;

    public void SpawnClient() //Spawn un client normal
    {
        Instantiate(_clientPrefab, transform.position, transform.rotation);
    }

    public void SpawnError() //Spawn un client erreur
    {
        Instantiate(_errorPrefab, transform.position, transform.rotation);
    }
}
