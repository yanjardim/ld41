using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Image;
    public Action Action;
    public bool IsEnable;
    public int TurnsUnabledAfterUse;
    private Actor _owner;
    private int _currentUnabledTurn;

    public void Init(Actor owner)
    {
        TurnController.OnTurnBegin += OnTurnBegin;
        IsEnable = true;
        _owner = owner;

    }

    void OnTurnBegin(Actor currentActor)
    {
        if (!IsEnable && _owner.IsMyTurn)
        {
            if (_currentUnabledTurn >= TurnsUnabledAfterUse)
            {
                IsEnable = true;
            }
            _currentUnabledTurn++;
        }
    }

    public void SetUnable()
    {
        IsEnable = false;
        _currentUnabledTurn = 0;
    }

    public void Use(Actor target)
    {
        if (Action == null)
        {
            Debug.LogWarning("This card have no Action");
            return;
        }
        if (!IsEnable)
        {
            Debug.LogWarning("Card Unabled");
            return;
        }
        _owner.Act(this, _owner, target);
        SetUnable();
    }
}
