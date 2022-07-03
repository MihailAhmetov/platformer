using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private float _speed;

    public int Damage => _damage;
    public int Health => _health;
    public float Speed => _speed;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(Damage);
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (Health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject, 0.1f);
    }
}
