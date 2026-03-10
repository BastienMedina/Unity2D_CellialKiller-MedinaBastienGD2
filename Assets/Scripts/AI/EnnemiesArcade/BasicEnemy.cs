using UnityEngine;
using UnityEngine.Rendering;

public class BasicEnemy : Enemy
{
    private FlipBookAnimation _flipbookAnim;

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if(_isAttacking == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
            if (_flipbookAnim == null)
            {
                _flipbookAnim = GetComponent<FlipBookAnimation>();
                _flipbookAnim.ActivateFlipbook(true);
            }
            else
            {
                _flipbookAnim.ActivateFlipbook(true);
            }
        }
        else
        {
            if (_flipbookAnim == null)
            {
                _flipbookAnim = GetComponent<FlipBookAnimation>();
                _flipbookAnim.ActivateFlipbook(false);
            }
            else
            {
                _flipbookAnim.ActivateFlipbook(false);
            }
        }
    }
}
