using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : WeaponComponent
{
    [SerializeField] private bool infiniteAmmo = false;

    [SerializeField] private int maxAmmo = 240;
    [SerializeField] private int maxAmmoPerClip = 24;
    
    private int ammoInClip;
    private int ammoRemainingNotInClip;

    public event Action OnAmmoChanged = delegate { };

    private void Start()
    {
        ammoInClip = maxAmmoPerClip;
        ammoRemainingNotInClip = maxAmmo - maxAmmoPerClip;
        OnAmmoChanged();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(Reload());
        }
    }

    protected override void WeaponFired()
    {
        RemoveAmmo();
    }

    private void RemoveAmmo()
    {
        Debug.Log($"removing ammo");
        ammoInClip--;
        OnAmmoChanged();
    }

    private IEnumerator Reload() {
        int ammoMissingInClip = maxAmmoPerClip - ammoInClip;
        int ammoToLoad = Math.Min(ammoMissingInClip, ammoRemainingNotInClip);

        if (infiniteAmmo) {
            ammoToLoad = ammoMissingInClip;
        }

        if (ammoToLoad > 0) {
            yield return new WaitForSeconds(0.1f);
            ammoInClip += ammoToLoad;
            ammoRemainingNotInClip -= ammoToLoad;
            if (infiniteAmmo) {
                ammoRemainingNotInClip = 0;
            }
            OnAmmoChanged();
        }

    }

    internal bool IsAmmoReady()
    {
        return ammoInClip > 0;
    }

    internal string GetAmmoText()
    {
        if (infiniteAmmo) {
            return $"{ammoInClip}/∞";
        }
        return $"{ammoInClip}/{ammoRemainingNotInClip}";
    }
}
