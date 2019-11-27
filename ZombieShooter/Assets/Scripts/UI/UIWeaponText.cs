using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWeaponText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;
    private WeaponAmmo currentWeaponAmmo;

    void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
        Inventory.OnWeaponChanged += Inventory_HandleWeaponChange;
    }

    private void Inventory_HandleWeaponChange(Weapon weapon)
    {
        if (currentWeaponAmmo != null) {
            currentWeaponAmmo.OnAmmoChanged -= CurrentWeaponAmmo_OnAmmoChanged;
        }
        currentWeaponAmmo = weapon.GetComponent<WeaponAmmo>();
        if (currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChanged += CurrentWeaponAmmo_OnAmmoChanged;
            tmproText.text = currentWeaponAmmo.GetAmmoText();
        }
        else
        {
            tmproText.text = "Unlimited";
        }
    }

    private void CurrentWeaponAmmo_OnAmmoChanged()
    {
        tmproText.text = currentWeaponAmmo.GetAmmoText();
    }

}
