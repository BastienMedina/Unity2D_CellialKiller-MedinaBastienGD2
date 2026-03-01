using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject _player;

    void Follow() //Déplace cet objet vers la position du joueur
    {
        if (_player == null) //Si le joueur n'est pas encore trouvé, le cherche par tag
        {
            _player = GameObject.FindWithTag("Player");
        }
        else
        {
            Vector3 nowPos = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
            transform.position = nowPos; //Met à jour la position de cet objet sur celle du joueur
        }
    }

    void Update() //Appelle Follow pour mettre à jour la position à chaque frame
    {
        Follow();
    }
}
