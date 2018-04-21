using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{

    public Actor target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(Card card)
    {
        card.Action.DoAction(GameController.Instance, target);
    }
}
