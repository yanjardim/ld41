using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardChooseController : MonoBehaviour
{
    public GameObject CardPrefab;
    public GameObject WeaponPrefab;

    public Transform CardsPanel;
    public Transform WeaponsPanel;
    public List<Card> CardsToShow;
    public List<Weapon> WeaponsToShow;
    public List<Card> CardsSelected;
    public List<Weapon> WeaponsSelected;
    public int MaxCardsSelected;
    public int MaxWeaponsSelected;
    // Use this for initialization
    void Start()
    {
        SpawnCards();
        SpawnWeapons();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnCards()
    {
        foreach (var card in CardsToShow)
        {

            GameObject newGO = Instantiate(CardPrefab, CardsPanel, false);
            CardPrefab cardPrefab = newGO.GetComponent<CardPrefab>();
            cardPrefab.SetCard(card.Name, card.Description, card.Image, card);
            Button cardButton = newGO.GetComponent<Button>();
            cardButton.onClick.AddListener(delegate { SelectCard(cardPrefab); });
        }
    }

    public void SpawnWeapons()
    {
        foreach (var card in WeaponsToShow)
        {

            GameObject newGO = Instantiate(WeaponPrefab, WeaponsPanel, false);
            WeaponPrefab cardPrefab = newGO.GetComponent<WeaponPrefab>();
            cardPrefab.SetCard(card.Name, card.Description, card.Image, card);
            Button cardButton = newGO.GetComponent<Button>();
            cardButton.onClick.AddListener(delegate { SelectWeapon(cardPrefab); });
        }
    }

    void SelectCard(CardPrefab card)
    {
        if (CardsSelected.Count >= MaxCardsSelected)
        {
            if (card.IsSelected)
            {
                card.IsSelected = false;
                CardsSelected.Remove(card.Card);
            }
            return;
        }
        if (card.IsSelected)
        {
            CardsSelected.Remove(card.Card);
        }
        else
        {
            CardsSelected.Add(card.Card);
        }
        SwapSelected(card);
    }

    void SelectWeapon(WeaponPrefab weapon)
    {
        if (WeaponsSelected.Count >= MaxCardsSelected)
        {
            if (weapon.IsSelected)
            {
                weapon.IsSelected = false;
                WeaponsSelected.Remove(weapon.Weapon);
            }
            return;
        }
        if (weapon.IsSelected)
        {
            WeaponsSelected.Remove(weapon.Weapon);
        }
        else
        {
            WeaponsSelected.Add(weapon.Weapon);
        }
        weapon.IsSelected = !weapon.IsSelected;
    }

    void SwapSelected(CardPrefab card)
    {
        card.IsSelected = !card.IsSelected;
    }

    public void StartGame()
    {
        CardManager.Instance.Init(CardsSelected, WeaponsSelected);
        SceneManager.LoadScene("Game");
    }
}


