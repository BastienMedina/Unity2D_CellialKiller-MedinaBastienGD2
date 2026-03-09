using UnityEngine;
using System.Collections.Generic;

public class SetPlayerHealthbar : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _heartLeftPrefab;
    [SerializeField] private GameObject _heartRightPrefab;
    [SerializeField] private Transform _vertBox;

    private List<GameObject> _heartList = new List<GameObject> ();

    public void SetAllHealth()
    {
        if (_player == null)
        {
            _player = GameObject.FindWithTag("Player");
        }
        int max = _player.GetComponent<PlayerArcade>().GetMaxHp();
        for (int i = 0; i < max; i++)
        {
            if (i % 2 == 0)
            {
                GameObject newH = Instantiate(_heartLeftPrefab, _vertBox);
                _heartList.Add(newH);
            }
            else
            {
                GameObject newH = Instantiate(_heartRightPrefab, _vertBox);
                _heartList.Add(newH);
            }
        }
    }

    public void RemoveHeart(int count)
    {
        for(int i = 0; i<count; i++)
        {
            GameObject removeH = _heartList[_heartList.Count - 1];
            _heartList.Remove(removeH);
            Destroy(removeH);
        }
    }
}
