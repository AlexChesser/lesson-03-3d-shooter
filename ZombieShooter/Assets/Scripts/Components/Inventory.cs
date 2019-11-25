using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    void Update()
    {
        foreach (Weapon weapon in weapons) {
            if (Input.GetKeyDown(weapon.HotKey)) {
                SwitchToWeapon(weapon);
                break;
            }
        }
    }

    private void SwitchToWeapon(Weapon weaponToSwitchTo)
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == weaponToSwitchTo);
        }
    }
}
