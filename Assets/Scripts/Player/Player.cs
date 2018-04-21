using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public Actor target;
    public void Act(Card card)
    {
        card.Action.DoAction(GameController.Instance, target);
    }

}
