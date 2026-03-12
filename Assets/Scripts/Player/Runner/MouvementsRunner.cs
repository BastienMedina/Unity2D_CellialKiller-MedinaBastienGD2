using UnityEngine;

public class MouvementsRunner : MonoBehaviour
{
    // Caméra utilisée pour convertir la position écran en position monde
    private Camera _cam;

    [Header("Movement Settings")]

    // Vitesse à laquelle le joueur suit le doigt
    [SerializeField] private float _moveSpeed = 15f;

    // Limite de déplacement gauche / droite
    [SerializeField] private float _xLimit = 3f;

    void Start()
    {
        // On récupère la caméra principale
        _cam = Camera.main;
    }

    public void MoveToScreenPosition(Vector2 screenPos)
    {
        // Conversion position écran -> position monde
        Vector3 worldPos = _cam.ScreenToWorldPoint(
            new Vector3(screenPos.x, screenPos.y, 10f)
        );

        // On limite la position X pour empêcher le joueur de sortir de l'écran
        float targetX = Mathf.Clamp(worldPos.x, -_xLimit, _xLimit);

        // On garde la position actuelle
        Vector3 newPos = transform.position;

        // On modifie seulement l'axe X
        newPos.x = Mathf.Lerp(
            transform.position.x, // position actuelle
            targetX,              // position cible
            _moveSpeed * Time.deltaTime // vitesse de déplacement
        );

        // On applique la nouvelle position
        transform.position = newPos;
    }
}
