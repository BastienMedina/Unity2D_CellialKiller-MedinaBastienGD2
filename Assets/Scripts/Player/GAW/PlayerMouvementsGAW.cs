using UnityEngine;

public class PlayerMouvementsGAW : MonoBehaviour
{
    [SerializeField] private Transform[] _playerPosList;

    private int _playerPosIndex = 0;

    void Start() //Déplace le joueur à la position de départ
    {
        Move(_playerPosIndex);
    }

    public void MoveLeft() //Déplace le joueur vers la gauche si possible
    {
        if (_playerPosIndex > 0) //Vérifie que le joueur n'est pas déjà à l'extrême gauche
        {
            int tempID = _playerPosIndex - 1;
            Move(tempID);
        }
    }

    public void MoveRight() //Déplace le joueur vers la droite si possible
    {
        if (_playerPosIndex < _playerPosList.Length - 1) //Vérifie que le joueur n'est pas déjà à l'extrême droite
        {
            int tempID = _playerPosIndex + 1;
            Move(tempID);
        }
    }

    void Move(int id) //Déplace le joueur à la position id
    {
        Vector3 newPos = _playerPosList[id].position;
        transform.position = newPos;
        _playerPosIndex = id;
    }
} 
