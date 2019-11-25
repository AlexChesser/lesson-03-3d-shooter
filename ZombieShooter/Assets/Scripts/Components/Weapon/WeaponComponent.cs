using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public abstract class WeaponComponent : MonoBehaviour
{
    protected Weapon weapon;
    protected abstract void WeaponFired();
    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        weapon.OnFire += Weapon_OnFire;
    }

    private void OnDestroy()
    {
        weapon.OnFire -= Weapon_OnFire;
    }

    private void Weapon_OnFire()
    {
        WeaponFired();
    }
}
