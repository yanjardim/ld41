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

    private void Start()
    {
        Init(new Queue<Actor>(GameController.Instance.Actors));
    }
    public void Init(Queue<Actor> actors)
    {
        this.Actors = actors;
        SetPlayerTurn();
        CallOnTurnBegin();
    }

    public void ChangeTurn()
    {
        CallOnTurnEnd();
        UnsetPlayerTurn();
        ReorderCurrentActor();
        SetPlayerTurn();
        CallOnTurnBegin();
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

    private void CallOnTurnBegin()
    {
        if (OnTurnBegin != null)
            OnTurnBegin(CurrentActorTurn);
    }

    private void CallOnTurnEnd()
    {
        if (OnTurnEnd != null)
            OnTurnEnd(CurrentActorTurn);
    }
}
