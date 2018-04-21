using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public int Health;
    public int MaxHealth;
    public int Strength;
    public int Defense;
    public int Agility;
    public bool IsDead
    {
        get
        {
            return Health <= 0;
        }
    }

    public void Init()
    {
        Health = MaxHealth;
    }

    public void Heal(int amount)
    {
        Health += amount;
        Health = Health >= MaxHealth ? MaxHealth : Health;
    }
    public void TakeDamage(int amount)
    {
        Health -= amount;
        Health = Health <= 0 ? 0 : Health;
    }
    public void AddStrength(int amount)
    {
        Strength += amount;
    }
    public void AddDefense(int amount)
    {
        Defense += amount;
    }
    public void AddAgility(int amount)
    {
        Agility += amount;
    }

}
