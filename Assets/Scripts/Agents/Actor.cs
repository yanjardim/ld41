using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public bool IsMyTurn = false;
    public Stats Stats;
    public List<Card> Cards;
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

    public virtual void Act(Card card, Actor currentActor, Actor target)
    {
        card.Action.DoAction(GameController.Instance, this, target);
    }
}
