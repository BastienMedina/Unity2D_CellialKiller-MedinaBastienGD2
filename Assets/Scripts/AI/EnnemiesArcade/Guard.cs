using UnityEngine;

public class Guard : Enemy
{
    private FlipBookAnimation _flipbookAnim;

    void Update() // Appelle FollowPlayer pour suivre le joueur
    {
        FollowPlayer();
    }

    void FollowPlayer() // Suit le joueur si pas en attaque
    {
        if (_isAttacking == false) // Si pas en train d'attaquer
        {
            if (_player == null) // Si pas de joueur
            {
                if (_flipbookAnim == null) // Si pas de référence à l'animation
                {
                    _flipbookAnim = GetComponent<FlipBookAnimation>();
                    _flipbookAnim.ActivateFlipbook(false); // Désactive l'animation
                }
                else
                {
                    _flipbookAnim.ActivateFlipbook(false); // Désactive l'animation
                }
                return;
            }

            transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime); // Avance vers le joueur
            if (_flipbookAnim == null) // Si pas de référence à l'animation
            {
                _flipbookAnim = GetComponent<FlipBookAnimation>();
                _flipbookAnim.ActivateFlipbook(true); // Active l'animation
            }
            else
            {
                _flipbookAnim.ActivateFlipbook(true); // Active l'animation
            }
        }
    }
}
