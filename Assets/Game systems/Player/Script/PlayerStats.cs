using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int _health;
    private int _maxHealth = 100;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        print("dead");
    }
}
