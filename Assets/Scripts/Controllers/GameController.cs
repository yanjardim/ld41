using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController Instance;
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
