using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _secondes = 0;
    [SerializeField] private int _minutes = 0;
    [SerializeField] private TextMeshProUGUI _text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SetSecondes", 0f, 1f);
        InvokeRepeating("SetMinutes", 60f, 60f);
    }

    void SetMinutes()
    {
        _secondes = 0;
        _minutes ++;
        _text.text = $"{_minutes} : {_secondes}";
    }

    void SetSecondes()
    {
        _secondes++;
        _text.text = $"{_minutes} : {_secondes}";
    }
}
