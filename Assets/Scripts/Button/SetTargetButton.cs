using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTargetButton : MonoBehaviour
{

    private Button _button;
    private Actor _actor;
    // Use this for initialization
    void Start()
    {
        _button = GetComponent<Button>();
        _actor = GetComponent<Actor>();
        AddButtonListener();
    }

    void AddButtonListener()
    {
        _button.onClick.AddListener(SetTarget);
    }

    void SetTarget()
    {
        if (!Player.Instance.IsMyTurn)
        {
            Debug.LogWarning("Not your turn");
            return;
        }

        Player.Instance.ChangeTarget(_actor);
    }


}
