using System;
using UnityEngine;

public abstract class Capacity : MonoBehaviour
{
    public CapacityEnum capacityName;
    public float cooldown;
    protected int damage;
    protected GameObject capacityPrefab;

    private void Awake()
    {
        // capacityPrefab = PlayerCapacities.
    }

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
