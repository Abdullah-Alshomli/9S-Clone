using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPComponent : MonoBehaviour
{
    [SerializeField] private int HP = 10;

    public int Hp
    {
        get => HP;
        set => HP = value;
    }


    public void TakeDamage(int Damage)
    {
        HP -= Damage;
    }
    
    public void Heal(int HealAmount)
    {
        HP += HealAmount;
    }

}
