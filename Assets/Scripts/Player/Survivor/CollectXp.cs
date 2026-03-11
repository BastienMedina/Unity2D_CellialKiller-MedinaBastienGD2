using UnityEngine;

public class CollectXp : MonoBehaviour
{
    [SerializeField] private ScoresCount _scoreCount;

    private bool _isCollecting = false;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Xp>() != null && _isCollecting == false)
        {
            _isCollecting = true;
            _scoreCount.Score += 1;
            Destroy(collider.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        _isCollecting = false;
    }
    
}
