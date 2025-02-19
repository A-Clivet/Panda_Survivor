using UnityEngine;

public class UltraSound : Capacity
{
    protected override void ExecuteCapacity()
    {
        Debug.Log("UltraSound");
        TimerManager.StartTimer(cooldown, ExecuteCapacity);
    }
}