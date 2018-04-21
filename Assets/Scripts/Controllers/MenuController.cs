using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public Text TxtTurn;

    // Use this for initialization
    void Start()
    {
        TurnController.OnTurnBegin += ChangeTextWhenTurnBegin;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeTextWhenTurnBegin(Actor actor)
    {
        TxtTurn.text = actor.name;
    }
}
