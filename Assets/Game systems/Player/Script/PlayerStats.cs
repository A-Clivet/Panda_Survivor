using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action<int, int> XpChanged;
    
    private int _health;
    private int _maxHealth = 100;
    private int _xp = 0;
    private int _xpRequired = 15;
    private int _level = 1;

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
    
    
    public void AddXP(int xp)
    {
        _xp += xp;
        XpChanged?.Invoke(_xp, _xpRequired);
        if (_xp >= _xpRequired)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        _xp -= _xpRequired;
        _xpRequired += 10;
        XpChanged?.Invoke(_xp, _xpRequired);
        _level++;
        //mettre sur pause le jeu et afficher le choix des bonus
    }

    public void AddSoul(int soulValue)
    {
        throw new NotImplementedException();
    }
}
