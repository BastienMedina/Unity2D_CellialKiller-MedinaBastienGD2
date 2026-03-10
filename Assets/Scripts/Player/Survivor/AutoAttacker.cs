using UnityEngine;
using System.Collections.Generic;

public class AutoAttacker : MonoBehaviour
{
    [SerializeField] private float _interval = 3.5f;
    [SerializeField] private float _damages = 10f;

    private List<GameObject> enemiesInRange = new List<GameObject>();

    private float _timer;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            enemiesInRange.Add(collider.gameObject);
            if (enemiesInRange.Count == 1)
            {
                InvokeRepeating(nameof(Attack), 0f, _interval);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collider.gameObject);
            if (enemiesInRange.Count == 0)
            {
                CancelInvoke(nameof(Attack)); // Arr�te d�attaquer si plus d�ennemis
            }
        }
    }

    void Attack()
    {
        if (enemiesInRange.Count > 0)
        {
            Debug.Log("attack auto !!");

            for (int i = enemiesInRange.Count - 1; i >= 0; i--)
            {
                GameObject enemy = enemiesInRange[i];

                if (enemy == null)
                {
                    enemiesInRange.RemoveAt(i);
                    continue;
                }

                enemy.GetComponent<Enemy>().TakeDamages(_damages);
            }
        }
    }

    public void IncreaseDamages()
    {
        _damages += 5f;
    }

    public void DecreaseInterval()
    {
        if (_interval > 0.1f)
        {
            _interval -= 0.3f;
        }
    }
}
