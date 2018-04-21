using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{

    public Queue<Actor> Actors;
    public Actor CurrentActorTurn;
    public delegate void TurnHandler(Actor CurrentActor);
    public static event TurnHandler OnTurnEnd;
    public static event TurnHandler OnTurnBegin;


    public void Init(Queue<Actor> actors)
    {
        this.Actors = actors;
        SetPlayerTurn();
    }

    public void ChangeTurn()
    {
        if (OnTurnEnd != null)
            OnTurnEnd(CurrentActorTurn);

        UnsetPlayerTurn();
        ReorderCurrentActor();
        SetPlayerTurn();

        if (OnTurnBegin != null)
            OnTurnBegin(CurrentActorTurn);
    }
    public void ReorderCurrentActor()
    {

        Actor currentActor = CurrentActorTurn;
        Actors.Dequeue();
        Actors.Enqueue(currentActor);
    }

    public void SetPlayerTurn()
    {
        CurrentActorTurn = Actors.Peek();
        CurrentActorTurn.IsMyTurn = true;
    }
    public void UnsetPlayerTurn()
    {
        CurrentActorTurn.IsMyTurn = false;
    }
}
