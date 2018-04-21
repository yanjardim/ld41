using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Levelup Action", menuName = "Actions/Levelup Action")]
public class LevelupAction : Action
{
    public override void DoAction(GameController controller, Actor currentActor, Actor target)
    {
        currentActor.Stats.LevelUp();
        DidAction(controller);
    }
}
