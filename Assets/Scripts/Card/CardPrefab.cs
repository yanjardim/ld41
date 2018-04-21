using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPrefab : MonoBehaviour
{

    public Text TxtName;
    public Text TxtDescription;
    public Image ImgIcon;
    // Use this for initialization
    public void SetCard(string name, string description, Sprite img)
    {
        TxtName.text = name;
        TxtDescription.text = description;
        ImgIcon.sprite = img;
    }
}
