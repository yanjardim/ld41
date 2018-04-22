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


    private void Start()
    {

        GetEnemies();
    }

    public void StartGame()
    {
        SpawnCards();
        SpawnWeapons();
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
        foreach (var card in Player.Instance.Cards)
        {
            Card newCardInstance = Object.Instantiate(card) as Card;
            newCardInstance.Init(Player.Instance);
            GameObject newGO = Instantiate(CardPrefab, CardParent, false);
            CardPrefab cardPrefab = newGO.GetComponent<CardPrefab>();
            Button cardButton = newGO.GetComponent<Button>();
            cardPrefab.SetCard(card.Name, card.Description, card.Image, newCardInstance);
            cardButton.onClick.AddListener(delegate { CardDoAction(newCardInstance); });
        }
    }

    public void SpawnWeapons()
    {
        Weapon weapon = ScriptableObject.CreateInstance(typeof(Weapon)) as Weapon;
        weapon.Init(new Stats(0, 0, 0, 1, 0, 0));
        Player.Instance.Inventory.EquipWeapon(weapon);

    }

    public void CardDoAction(Card card)
    {
        card.Use(Player.Instance.Target);
    }
}
