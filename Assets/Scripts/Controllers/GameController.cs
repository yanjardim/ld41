using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Actor> Actors;
    public TurnController TurnController;
    public void StartFight(List<Actor> actors)
    {
        Actors = actors;
        //Actors.Shuffle();
        TurnController.Init(new Queue<Actor>(Actors));
    }

    private void Start()
    {
        StartFight(Actors);
    }

}
