using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    #region Singleton
    public static CardManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    public List<Card> Cards;
    public List<Weapon> Weapons;

    public void Init(List<Card> cards, List<Weapon> weapons)
    {
        Cards = cards;
        Weapons = weapons;
    }

}
