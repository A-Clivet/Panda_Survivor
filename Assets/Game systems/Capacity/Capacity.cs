using System;
using UnityEngine;

public abstract class Capacity : MonoBehaviour
{
    public CapacityEnum capacityName;
    public float cooldown;
    protected int damage;
    

    private void Start()
    {
        ExecuteCapacity();
    }

    protected abstract void ExecuteCapacity();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
