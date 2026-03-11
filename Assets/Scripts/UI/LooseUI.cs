using System.Diagnostics;
using UnityEngine;

public class LooseUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] _removableScreen;

    void RemoveAllUi()
    {
        foreach(CanvasGroup screen in _removableScreen)
        {
            screen.alpha = 0;
            screen.blocksRaycasts = false;
            screen.interactable = false;
        }
    }

    void Start()
    {
        RemoveAllUi();
        Time.timeScale = 0;
    }

    public void ReturnMenu()
    {
        GetComponent<LoadNewScene>().Load();
    }
}
