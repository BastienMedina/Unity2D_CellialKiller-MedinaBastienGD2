using UnityEngine;

public class InputManagerGAW : MonoBehaviour
{
    [SerializeField] private float _minDistSwipe = 50f;

    private Vector2 startPos;
    private PlayerMouvementsGAW player;

    void Start()
    {
        player = GetComponent<PlayerMouvementsGAW>();
    }

    void Update()
    {
        // MOBILE
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                startPos = touch.position;

            else if (touch.phase == TouchPhase.Ended)
                DetectSwipe(touch.position);

            return; // empêche le code PC de s'exécuter
        }

        // PC
        if (Input.GetMouseButtonDown(0))
            startPos = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
            DetectSwipe(Input.mousePosition);
    }

    void DetectSwipe(Vector2 endPos)
    {
        float deltaX = endPos.x - startPos.x;

        if (Mathf.Abs(deltaX) < _minDistSwipe)
            return;

        if (deltaX > 0)
            player.MoveRight();
        else
            player.MoveLeft();
    }
}
