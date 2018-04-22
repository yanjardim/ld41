using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Weapon> Weapons;
    public delegate void InventoryHandler(Weapon weapon);
    public event InventoryHandler OnEquipWeapon;
    public event InventoryHandler OnUnequipWeapon;

    public void EquipWeapon(Weapon weapon)
    {
        Debug.Log(OnEquipWeapon);
        if (OnEquipWeapon != null)
        {
            Debug.Log("On Equip");
            OnEquipWeapon(weapon);
        }
        Weapons.Add(weapon);
        Debug.Log("Equip");
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
