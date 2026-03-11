using TMPro;
using UnityEngine;

public class TextPhoneCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        SetText();
    }

    void SetText()
    {
        if (_player == null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        if(_player.GetComponent<PhoneThrower>().GetCurrentPhoneStock() < 0)
        {
            _text.text = $"0 / {_player.GetComponent<PhoneThrower>().GetMaxPhone()}";
        }
        else
        {
            _text.text = $"{_player.GetComponent<PhoneThrower>().GetCurrentPhoneStock()} / {_player.GetComponent<PhoneThrower>().GetMaxPhone()}";
        }
    }
}
