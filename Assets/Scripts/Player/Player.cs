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
    public Actor target;
    public void Act(Card card)
    {
        card.Action.DoAction(GameController.Instance, this, target);
    }

}
