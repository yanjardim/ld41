using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal Action", menuName = "Actions/Heal Action")]
public class HealAction : Action
{
    public override void DoAction(GameController controller, Actor currentActor, Actor target)
    {
        currentActor.Stats.Heal(4);
        DidAction(controller);
    }
}
