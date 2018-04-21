using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Action : ScriptableObject
{
    public abstract void DoAction(GameController controller, Actor currentActor, Actor target);
    protected virtual void DidAction(GameController controller)
    {
        controller.TurnController.ChangeTurn();
    }
}
