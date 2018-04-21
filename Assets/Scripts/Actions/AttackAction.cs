using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Action", menuName = "Actions/Attack Action")]
public class AttackAction : Action
{
    public override void DoAction(GameController controller, Actor currentActor, Actor target)
    {
        Stats currentActorStats = currentActor.Stats;
        Stats targetStats = target.Stats;
        int damage = currentActorStats.Strength * currentActorStats.Strength / (currentActorStats.Strength + targetStats.Defense);
        targetStats.TakeDamage(damage);
        Debug.Log(damage);
        DidAction(controller);
    }

}
