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
    public bool _isInvunerable = false;
    private int _invunerabilityTurns = 0;
    private int _currentInvunerabilityTurn = 0;
    private Actor _thisActor;
    public bool IsDead
    {
        get
        {
            return Health <= 0;
        }
    }

    public Stats()
    {

    }
    public Stats(int health, int maxHealth, int level, int strength, int defense, int agility)
    {
        this.Health = health;
        this.MaxHealth = maxHealth;
        this.Level = level;
        this.Strength = strength;
        this.Defense = defense;
        this.Agility = agility;
    }

    //TODO: Add events when is dead
    public void Init(Actor thisActor)
    {
        Health = MaxHealth;
        _isInvunerable = false;
        _thisActor = thisActor;
        TurnController.OnTurnBegin += OnTurnBegin;
    }
    void OnTurnBegin(Actor currentActor)
    {
        if (_isInvunerable && _thisActor.IsMyTurn)
        {
            Debug.Log("Invuneravel");
            _currentInvunerabilityTurn++;
            if (_currentInvunerabilityTurn >= _invunerabilityTurns)
            {
                Debug.Log("Invuneravel");
                _isInvunerable = false;
            }
        }
    }
    public void Heal(int amount)
    {
        Health += amount;
        Health = Health >= MaxHealth ? MaxHealth : Health;
    }
    public void TakeDamage(Actor currentActor, Actor target)
    {
        if (_isInvunerable) return;

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
    public void Invunerable(int turns)
    {
        _isInvunerable = true;
        _invunerabilityTurns = turns;
        _currentInvunerabilityTurn = 0;
    }

    public static Stats operator +(Stats stat1, Stats stat2)
    {
        return new Stats(
            stat1.Health + stat2.Health,
            stat1.MaxHealth + stat2.MaxHealth,
            stat1.Level + stat2.Level,
            stat1.Strength + stat2.Strength,
            stat1.Defense + stat2.Defense,
            stat1.Agility + stat2.Agility
            );
    }
    public static Stats operator -(Stats stat1, Stats stat2)
    {
        return new Stats(
            stat1.Health - stat2.Health,
            stat1.MaxHealth - stat2.MaxHealth,
            stat1.Level - stat2.Level,
            stat1.Strength - stat2.Strength,
            stat1.Defense - stat2.Defense,
            stat1.Agility - stat2.Agility
            );
    }
}
