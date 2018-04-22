using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{

    public List<Actor> Actors;
    public Actor CurrentActorTurn;
    public delegate void TurnHandler(Actor CurrentActor);
    public static event TurnHandler OnTurnEnd;
    public static event TurnHandler OnTurnBegin;

    private void Start()
    {
        Init(GameController.Instance.Actors);
        foreach (var obj in Actors)
        {
            obj.Stats.WhenDie += WhenActorDies;
        }
    }
    public void Init(List<Actor> actors)
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
        Actors.RemoveAt(0);
        Actors.Add(currentActor);
    }

    private void WhenActorDies(Actor actor)
    {
        if (actor == null) return;
        if (actor.tag == "Player") return;

        Actors.Remove(actor);
        if (CurrentActorTurn == null)
        {
            SetPlayerTurn();
        }
        Destroy(actor.gameObject);
        Player.Instance.SetTarget();
    }

    public void SetPlayerTurn()
    {
        CurrentActorTurn = Actors[0];
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

    public void ChangeTurnWhenIsPlayerTurn()
    {
        if (Player.Instance.IsMyTurn)
        {
            ChangeTurn();
        }
        else
        {
            Debug.LogWarning("Isn't your turn");
        }
    }
}
