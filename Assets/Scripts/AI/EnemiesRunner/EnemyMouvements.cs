using UnityEngine;

public class EnemyMouvements : MonoBehaviour
{
    [Header("Vertical Movement")]

    // Vitesse de descente vers le bas de l'�cran
    [SerializeField] private float _downSpeed = 4f;

    [Header("ZigZag Movement")]

    // Largeur du zigzag (distance gauche / droite)
    [SerializeField] private float _zigzagWidth = 3f;

    // Vitesse du zigzag
    [SerializeField] private float _zigzagSpeed = 2f;

    // Position X de d�part (centre du zigzag)
    private float _startX;

    // Temps utilis� pour calculer le sinus
    private float _time;

    void Start()
    {
        // On enregistre la position X de d�part
        _startX = transform.position.x;
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // On augmente le temps pour animer le sinus
        _time += Time.deltaTime * _zigzagSpeed;

        // Calcul du zigzag avec une fonction sinus
        float zigzagX = Mathf.Sin(_time) * _zigzagWidth;

        // Calcul de la nouvelle position
        Vector3 newPos = transform.position;

        // Mouvement gauche / droite
        newPos.x = _startX + zigzagX;

        // Mouvement vers le bas
        newPos.y -= _downSpeed * Time.deltaTime;

        // Application de la position
        transform.position = newPos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindWithTag("Finish").GetComponent<LooseUI>().RemoveAllUi();
            Destroy(gameObject);
        }
        else if (collision.gameObject.GetComponent<DestroyExit>() != null)
        {
            Destroy(gameObject);
        }
    }
}
