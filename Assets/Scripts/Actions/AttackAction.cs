using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Action", menuName = "Actions/Attack Action")]
public class AttackAction : Action
{

    public override void DoAction(GameController controller, Actor target)
    {
        target.Stats.Health -= 1;
        Debug.Log("Atacou");
        DidAction(controller);
    }
}
