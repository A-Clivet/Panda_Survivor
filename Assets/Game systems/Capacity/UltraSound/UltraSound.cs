using System;
using UnityEngine;

public class UltraSound : Capacity
{
    protected override void ExecuteCapacity()
    {
        Debug.Log(capacityName + " capacity executed");
        TimerManager.StartTimer(cooldown, ExecuteCapacity);
    }
}