using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCapacities : MonoBehaviour
{
    [SerializeField] private GameObject[] _capacities;
    
    public Dictionary<CapacityEnum, GameObject> Capacities = new Dictionary<CapacityEnum, GameObject>();


    private void Awake()
    {
        Capacities.Add(CapacityEnum.Ultrasound, _capacities[0]);
        Capacities.Add(CapacityEnum.Wingtip, _capacities[1]);
    }
    
    public GameObject GetCapacity(CapacityEnum capacity)
    {
        return Capacities[capacity];
    }
}