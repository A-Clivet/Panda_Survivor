using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
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

    public void TakeDamage(int pDamage)
    {
        _health -= pDamage;
        if (_health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        print("dead");
    }
    
    //TODO ; deplacer le systeme d'xp dans un script a part
    public void AddXP(int xp)
    {
        _xp += xp;
        if (_xp >= _xpRequired)
        {
            LevelUp();
        }
        XpChanged?.Invoke(_xp, _xpRequired);
    }

    private void LevelUp()
    {
        _xp -= _xpRequired;
        _xpRequired += 100;
        _level++;
        TimerManager.Pause();
        //afficher le choix des bonus
        TimerManager.Resume();
    }

    public void AddSoul(int soulValue)
    {
        throw new NotImplementedException();
    }
}
