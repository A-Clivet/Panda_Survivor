using System;
using UnityEngine;

public class LittleFlame : Enemy
{
    private int _dropXP = 3;
    private void Awake()
    {
        dropXP = _dropXP;
    }
}
