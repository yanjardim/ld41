using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPrefab : MonoBehaviour
{

    public Text TxtName;
    public Text TxtDescription;
    public Text TxtTurns;
    public Image ImgIcon;
    public Image ImgSelected;
    public Weapon Weapon;
    public bool IsSelected;

    // Use this for initialization
    public void SetCard(string name, string description, Sprite img, Weapon weapon)
    {
        TxtName.text = name;
        TxtDescription.text = description;
        ImgIcon.sprite = img;
        Weapon = weapon;
        TxtTurns.text = weapon.TurnsUnabledAfterUse.ToString();
        IsSelected = false;
    }

    public void HandleSelected()
    {
        if (IsSelected)
        {
            ImgSelected.enabled = true;
        }
        else
        {
            ImgSelected.enabled = false;

        }
    }

    void Update()
    {
        HandleSelected();
    }
}
