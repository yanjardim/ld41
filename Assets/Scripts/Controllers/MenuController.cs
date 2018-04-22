using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{


    public Text TxtStrenght;
    public Text TxtDefense;
    public Image ImgHealthBar;
    public float LerpSpeed = 2;
    private Stats _playerStats;

    // Use this for initialization
    void Start()
    {

        _playerStats = Player.Instance.Stats;
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
        HandleStatsText();
    }


    void HandleBar()
    {
        ImgHealthBar.fillAmount = Mathf.Lerp(ImgHealthBar.fillAmount,
                                            Player.Instance.Stats.GetHealthAsPercent(),
                                            Time.deltaTime * LerpSpeed);
    }

    void HandleStatsText()
    {
        TxtDefense.text = _playerStats.Defense.ToString();
        TxtStrenght.text = _playerStats.Strength.ToString();
    }
}
