using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Card> Weapons;
    public delegate void InventoryHandler(Weapon weapon);
    public event InventoryHandler OnEquipWeapon;
    public event InventoryHandler OnUnequipWeapon;

    public void EquipWeapon(Weapon weapon)
    {
        if (OnEquipWeapon != null)
        {
            OnEquipWeapon(weapon);
        }
        Weapons.Add(weapon);
    }
    public void UnequipWeapon(Weapon weapon)
    {
        if (OnUnequipWeapon != null)
        {
            OnUnequipWeapon(weapon);
        }
        Weapons.Remove(weapon);
    }

}
