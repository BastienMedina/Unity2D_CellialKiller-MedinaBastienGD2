using System.Diagnostics;
using UnityEngine;

public class LooseUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] _removableScreen;

    public void RemoveAllUi()
    {
        foreach(CanvasGroup screen in _removableScreen)
        {
            screen.alpha = 0;
            screen.blocksRaycasts = false;
            screen.interactable = false;
        }
        CanvasGroup _screen = GetComponent<CanvasGroup>();
        _screen.alpha = 1;
        _screen.blocksRaycasts = true;
        _screen.interactable = true;
        //Time.timeScale = 0;
    }

    void Start()
    {
        CanvasGroup screen = GetComponent<CanvasGroup>();
        screen.alpha = 0;
        screen.blocksRaycasts = false;
        screen.interactable = false;
    }

    public void ReturnMenu()
    {
        GetComponent<LoadNewScene>().Load();
    }
}
