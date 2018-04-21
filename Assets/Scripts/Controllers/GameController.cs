using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public List<Actor> Enemies;
    public TurnController TurnController;
    public GameObject CardPrefab;
    public Transform CardParent;
    public Player player;

    private void Start()
    {
        StartGame();
        GetEnemies();
    }

    public void StartGame()
    {
        SpawnCards();
    }
    public void GetEnemies()
    {
        Enemies = new List<Actor>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var obj in objs)
        {
            Enemies.Add(obj.GetComponent<Actor>());
        }

    }
    public void SpawnCards()
    {
        foreach (var card in player.Cards)
        {
            GameObject newGO = Instantiate(CardPrefab, CardParent, false);
            CardPrefab cardPrefab = newGO.GetComponent<CardPrefab>();
            Button cardButton = newGO.GetComponent<Button>();
            cardPrefab.SetCard(card.Name, card.Description, card.Image, card);
            cardButton.onClick.AddListener(delegate { CardDoAction(card); });
        }
    }

    public void CardDoAction(Card card)
    {
        if (card.Action == null)
        {
            Debug.LogWarning("This card have no Action");
            return;
        }
        Player.Instance.Act(card);
    }
}
