using UnityEngine;

public class Seller : Enemy
{
    private bool _isFleeing;
    private SellerManager _sellerManager;
    private FlipBookAnimation _flipbookAnim;

    protected override void Start() // Initialise le vendeur et référence le manager
    {
        base.Start();
        _sellerManager = GameObject.Find("SellerManager").GetComponent<SellerManager>();
        _sellerManager.SetTotal(1);
        _flipbookAnim = GetComponent<FlipBookAnimation>();
    }

    protected override void Die() // Signale la mort au manager
    {
        _sellerManager.AddDead();
        base.Die();
    }

    void Update() // Gère le comportement chaque frame
    {
        if (_player == null) // Si pas de joueur ciblé
        {
            WalkAnim(true);
            return;
        }

        _isFleeing = _sellerManager.NeedFlee(); // Vérifie si le vendeur doit fuir

        if (_isFleeing) // Si doit fuir
        {
            Flee();
            WalkAnim(true);
        }
        else // Sinon attaque
        {
            Attack();
            WalkAnim(true);
        }
    }

    void Attack() // Avance vers le joueur si pas en attaque
    {
        if (_isAttacking == false) // Si pas en train d'attaquer
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
        }
    }

    void Flee() // Fuit le joueur
    {
        Vector2 dir = (transform.position - _player.position).normalized;
        transform.position += (Vector3)(dir * _speed * Time.deltaTime);
    }

    void WalkAnim(bool state) // Active l'animation de marche
    {
        if (_flipbookAnim == null) // Si pas de référence à l'animation
        {
            _flipbookAnim = GetComponent<FlipBookAnimation>();
            _flipbookAnim.ActivateFlipbook(state);
        }
        else
        {
            _flipbookAnim.ActivateFlipbook(state);
        }
    }
}
