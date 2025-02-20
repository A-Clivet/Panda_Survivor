using System;
using UnityEngine;

public class UltraSound : Capacity
{
    protected override void ExecuteCapacity()
    {
        Debug.Log("UltraSound");
        TimerManager.StartTimer(cooldown, ExecuteCapacity);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ennemy"))
        {
            other.GetComponent<Ennemies>().TakeDamage(damage);
        }
    }
}