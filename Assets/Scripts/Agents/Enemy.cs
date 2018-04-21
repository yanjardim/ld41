using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{

    public Vector2 CooldownRange;
    private bool _canPlay;
    // Use this for initialization
    void Start()
    {
        _canPlay = false;
        TurnController.OnTurnBegin += OnTurnBegin;
    }

    // Update is called once per frame
    void OnTurnBegin(Actor target)
    {
        if (!IsMyTurn) return;

        StartPlayCoroutine();
    }
    void Play()
    {
        Debug.Log("Enemy Attack!");
        GameController.Instance.TurnController.ChangeTurn();
    }

    void StartPlayCoroutine()
    {
        StartCoroutine(PlayAfterRandomTimeCoroutine());
    }

    IEnumerator PlayAfterRandomTimeCoroutine()
    {

        yield return new WaitForSeconds(Random.Range(CooldownRange.x, CooldownRange.y));
        Play();
    }
}
