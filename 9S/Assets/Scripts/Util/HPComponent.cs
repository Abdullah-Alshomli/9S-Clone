using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPComponent : MonoBehaviour
{
    [SerializeField] private int HP = 10;
    private bool isActive = true;


    public bool IsActive
    {
        get => isActive;
        set => isActive = value;
    }

    public int Hp
    {
        get => HP;
        set => HP = value;
    }


    public void TakeDamage(int Damage)
    {
        if (IsActive)
        {
            HP -= Damage;
        }
    }
    
    public void Heal(int HealAmount)
    {
        if (IsActive)
        {
            HP += HealAmount;
        }
    }
    
}
