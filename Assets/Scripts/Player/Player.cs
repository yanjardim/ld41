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

    public int Coins;
    public Actor Target;
    public delegate void TargetHandler(Actor target);
    public static event TargetHandler OnTargetChange;
    private void Start()
    {
        if (GameController.Instance.Enemies.Count > 0)
            ChangeTarget(GameController.Instance.Enemies[0]);
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

}
