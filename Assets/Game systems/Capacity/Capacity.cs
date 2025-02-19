using System;
using UnityEngine;

public abstract class Capacity : MonoBehaviour
{
    public CapacityEnum capacityName;
    public float cooldown;

    private void Start()
    {
        ExecuteCapacity();
    }

    protected abstract void ExecuteCapacity();
}
