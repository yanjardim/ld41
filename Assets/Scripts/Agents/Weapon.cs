using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon ")]
public class Weapon : Card
{
    public Stats Stats;
    public void Init(string name, string description, Sprite image, Stats stats)
    {
        Stats = stats;
        Name = name;
        Description = description;
        Image = image;
    }

}
