using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Action", menuName = "Actions/Attack Action")]
public class AttackAction : Action
{
    public override void DoAction(GameController controller, Actor currentActor, Actor target)
    {
        Debug.Log(currentActor);
        Debug.Log(target);
        target.Stats.TakeDamage(currentActor, target);
        DidAction(controller);
    }

}
