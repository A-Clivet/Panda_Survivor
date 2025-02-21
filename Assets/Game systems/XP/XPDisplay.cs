using System;
using UnityEngine;
using UnityEngine.UI;

public class XPDisplay : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Image xpBar;
    

    private void Awake()
    {
        playerStats.XpChanged += DisplayXP;
    }

    void DisplayXP(int xp, int xpRequired)
    {
        xpBar.fillAmount = (float)xp / xpRequired;
    }
}
