using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public bool IsMyTurn = false;
    public Stats Stats;
    public List<Card> Cards;
    public Inventory Inventory;
    public Actor()
    {
        IsMyTurn = false;


    }
    public Actor(Actor actor)
    {
        Stats = actor.Stats;
        Cards = actor.Cards;
        IsMyTurn = actor.IsMyTurn;
    }
    public virtual void Start()
    {
        Stats.Init(this);
        Inventory.OnEquipWeapon += OnWeaponEquiped;
        Inventory.OnUnequipWeapon += OnWeaponUnequiped;
        Debug.Log("Events add");
    }

    public virtual void Act(Card card, Actor currentActor, Actor target)
    {
        card.Action.DoAction(GameController.Instance, this, target);
    }

    private void OnWeaponEquiped(Weapon weapon)
    {
        Debug.Log("Equipou");
        Stats.Add(weapon.Stats);
    }
    private void OnWeaponUnequiped(Weapon weapon)
    {
        Stats.Sub(weapon.Stats);

    }
}
