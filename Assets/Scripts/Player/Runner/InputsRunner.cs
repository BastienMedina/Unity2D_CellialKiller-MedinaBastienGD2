using UnityEngine;

public class InputsRunner : MonoBehaviour
{
    // Référence vers le script de mouvement du joueur
    private MouvementsRunner _playerMovement;

    void Start()
    {
        // On récupère automatiquement le PlayerMovement dans la scène
        _playerMovement = FindFirstObjectByType<MouvementsRunner>();
    }

    void Update()
    {
#if UNITY_EDITOR
        HandleMouseInput(); // Si on joue dans l'éditeur Unity
#else
        HandleTouchInput(); // Si on joue sur mobile
#endif
    }

    void HandleTouchInput()
    {
        // Si aucun doigt sur l'écran on ne fait rien
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0); // On récupère le premier doigt

        // Si le doigt touche l'écran OU qu'il glisse
        if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
        {
            // On envoie la position du doigt au joueur
            _playerMovement.MoveToScreenPosition(touch.position);
        }
    }

    void HandleMouseInput()
    {
        // Si clic gauche maintenu (simulation du doigt dans l'éditeur)
        if (Input.GetMouseButton(0))
        {
            // On envoie la position de la souris au joueur
            _playerMovement.MoveToScreenPosition(Input.mousePosition);
        }
    }
}
