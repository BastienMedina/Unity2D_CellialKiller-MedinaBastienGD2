using UnityEngine;

public class PlayerMouvementsGAW : MonoBehaviour
{
    [SerializeField] private Transform[] _playerPosList;

    private int _playerPosIndex = 0;

    void Start()
    {
        Move(_playerPosIndex);
    }

    public void MoveLeft()
    {
        if (_playerPosIndex > 0)
            Move(_playerPosIndex - 1);
    }

    public void MoveRight()
    {
        if (_playerPosIndex < _playerPosList.Length - 1)
            Move(_playerPosIndex + 1);
    }

    void Move(int id)
    {
        transform.position = _playerPosList[id].position;
        _playerPosIndex = id;
    }
} 
