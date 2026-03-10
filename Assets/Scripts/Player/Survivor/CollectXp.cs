using UnityEngine;

public class CollectXp : MonoBehaviour
{
    [SerializeField] private ScoresCount _scoreCount;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Xp>() != null)
        {
            _scoreCount.Score++;
            Destroy(collider.gameObject);
        }
    }
}
