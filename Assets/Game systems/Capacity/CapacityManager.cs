using System;
using System.Collections.Generic;
using UnityEngine;

public class CapacityManager : MonoBehaviour
{
    public List<Capacity> AvailableCapacities = new List<Capacity>();

    public void UnlockAttack(CapacityEnum type, float cooldown = 3f)
    {
        if (gameObject.AddComponent(GetAttackComponent(type)) is Capacity newCapacity)
        {
            newCapacity.capacityName = type;
            newCapacity.cooldown = cooldown;
            AvailableCapacities.Add(newCapacity);
        }
    }

    private Type GetAttackComponent(CapacityEnum type)
    {
        switch (type)
        {
            case CapacityEnum.Ultrasound:
                return typeof(UltraSound);
            case CapacityEnum.Wingtip:
                return typeof(Wingtip);
            default:
                return null;
        }
    }
}