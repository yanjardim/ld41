using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public int Health;
    public int MaxHealth;
    public int Level;
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
    //TODO: Add events when is dead
    public void Init()
    {
        Health = MaxHealth;
    }

    public void Heal(int amount)
    {
        Health += amount;
        Health = Health >= MaxHealth ? MaxHealth : Health;
    }
    public void TakeDamage(Actor currentActor, Actor target)
    {
        Stats currentActorStats = currentActor.Stats;
        Stats targetStats = target.Stats;
        int damage = currentActorStats.Strength * currentActorStats.Strength / (currentActorStats.Strength + targetStats.Defense);
        Debug.Log(damage);
        Health -= damage;
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

    public void LevelUp()
    {
        Level++;
        AddStrength(1);
        AddDefense(1);
        AddAgility(1);
    }

    public float GetHealthAsPercent()
    {

        return (float)Health / (float)MaxHealth;
    }

}
