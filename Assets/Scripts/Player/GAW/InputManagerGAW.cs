using UnityEngine;

public class InputManagerGAW : MonoBehaviour
{
    [SerializeField] private float _minDistSwipe = 50f;

    private Vector2 startPos;

    void Update() //Appelle la détection de swipe
    {
        InputMoveSwipe();
    }

    void InputMoveSwipe() //Gère les entrées tactiles et souris
    {
        if (Input.touchCount > 0) //Si un doigt touche l'écran
        {
            Touch touche = Input.GetTouch(0);

            if (touche.phase == TouchPhase.Began) //Détecte le début du touch
            {
                startPos = touche.position;
            }
            if (touche.phase == TouchPhase.Ended) //Détecte la fin du touch
            {
                DetectSwipe(touche.position);
            }
        }

        //version PC
        if (Input.GetMouseButtonDown(0)) //Détecte clic souris début
            startPos = Input.mousePosition;

        if (Input.GetMouseButtonUp(0)) //Détecte clic souris fin
            DetectSwipe(Input.mousePosition);
    }

    void DetectSwipe(Vector2 endPos) //Détecte le sens du swipe
    {
        float deltaX = endPos.x - startPos.x;
        if (Mathf.Abs(deltaX) < _minDistSwipe) //Ignore si le swipe est trop petit
        {
            return;
        }
        if (deltaX > 0) //Swipe vers la droite
        {
            GetComponent<PlayerMouvementsGAW>().MoveRight();
        }
        else //Swipe vers la gauche
        {
            GetComponent<PlayerMouvementsGAW>().MoveLeft();
        }
    }
}
