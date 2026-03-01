using UnityEngine;

public class CollectClient : MonoBehaviour
{
    [SerializeField] private ScoresCount _scoreCount;

    void OnTriggerEnter2D(Collider2D collider) //Gère la collecte de clients
    {
        ClientMouvementsGAW client = collider.gameObject.GetComponent<ClientMouvementsGAW>();
        BadClient badClient = collider.gameObject.GetComponent<BadClient>();

        if (client != null) //Si c'est un client
        {
            if (badClient != null) //Si c'est un mauvais client
            {
                AddError();
                Destroy(client.gameObject);
            }
            else //Sinon, ajoute au score
            {
                _scoreCount.Score++;
                Destroy(client.gameObject);
            }
        }
    }

    void AddError() //Ajoute une erreur et déclenche un shake caméra
    {
        GetComponent<AddCrossError>().AddError();
        GameObject.Find("Main Camera").GetComponent<ShakeAnimation>().LaunchShake(0.2f, 0.15f, 25f);
    }
}
