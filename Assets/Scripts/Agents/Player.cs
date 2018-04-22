using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    #region Singleton
    public static Player Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public Actor Target;


    public delegate void TargetHandler(Actor target);
    public static event TargetHandler OnTargetChange;

    private void Start()
    {
        base.Start();
        Cards = CardManager.Instance.Cards;
        Inventory.Weapons = CardManager.Instance.Weapons;
        GameController.Instance.StartGame();
        SetTarget();

    }
    public void ChangeTarget(Actor target)
    {
        Target = target;
        if (OnTargetChange != null)
        {
            OnTargetChange(Target);
        }
    }
    public void Act(Card card)
    {
        if (!IsMyTurn)
        {
            Debug.LogWarning("Not your turn");
            return;
        }

        card.Action.DoAction(GameController.Instance, this, Target);
    }

    public void SetTarget()
    {
        if (GameController.Instance.TurnController.Actors.Count > 1)
            ChangeTarget(GameController.Instance.TurnController.Actors[1]);
    }

}
