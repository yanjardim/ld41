using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{

    public Vector2 CooldownRange;
    private bool _canPlay;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
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
        UseCard(PickRandomCard());
        //GameController.Instance.TurnController.ChangeTurn();
    }
    void UseCard(Card card)
    {
        Act(card, this, Player.Instance);
    }
    Card PickRandomCard()
    {
        return Cards[Random.Range(0, Cards.Count - 1)];
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
