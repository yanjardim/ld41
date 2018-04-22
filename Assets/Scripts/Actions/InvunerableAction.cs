using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Invunerable Action", menuName = "Actions/Invunerable")]
public class InvunerableAction : Action
{
    public int Turns;
    public override void DoAction(GameController controller, Actor currentActor, Actor target)
    {
        currentActor.Stats.Invunerable(Turns);
        DidAction(controller);
    }
}
