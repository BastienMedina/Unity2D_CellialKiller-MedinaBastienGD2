using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _speed = 3f;
    [SerializeField] private int _damages = 1;
    [SerializeField] private float _damagesRate = 2f;
    [SerializeField] private float _maxHp = 100f;
    [SerializeField] private float _Hp = 2f;
    

    protected Transform _player;
    private float _curentTimer;
    protected bool _isAttacking = false;

    protected virtual void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _Hp = _maxHp;
    }

    public virtual void TakeDamages(float damage)
    {
        _Hp -= damage;
        if (_Hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject col = collider.gameObject;

        if (col.CompareTag("Player"))
        {
            _isAttacking = true;
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collider)
    {
        GameObject col = collider.gameObject;

        if (col.CompareTag("Player"))
        {
            _curentTimer += Time.deltaTime;
            if (_curentTimer >= _damagesRate)
            {
                _curentTimer = 0;
                col.GetComponent<PlayerArcade>().TakeDamages(_damages);
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        GameObject col = collider.gameObject;

        if (col.CompareTag("Player"))
        {
            _curentTimer = 0;
            _isAttacking = false;
        }
    }
}
