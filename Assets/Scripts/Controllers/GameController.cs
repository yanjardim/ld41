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
    public GameObject CardPrefab;
    public Transform CardParent;
    public Player player;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        SpawnCards();
    }

    public void SpawnCards()
    {
        foreach (var card in player.Cards)
        {
            GameObject newGO = Instantiate(CardPrefab, CardParent, false);
            CardPrefab cardPrefab = newGO.GetComponent<CardPrefab>();
            cardPrefab.SetCard(card.Name, card.Description, card.Image);
        }
    }

}
