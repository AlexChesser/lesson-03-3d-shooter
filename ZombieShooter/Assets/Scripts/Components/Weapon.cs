using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private KeyCode hotKey;
    [SerializeField] private float fireDelay = 0.25f;
    public KeyCode HotKey => hotKey;
    public event Action OnFire = delegate { };

    private float fireTimer = 0f;

    private bool CanFire() {
        return fireTimer > fireDelay;
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButton("Fire1")) {
            if (CanFire()) {
                Fire();
            }
        }
    }

    private void Fire()
    {
        fireTimer = 0;
        OnFire();
        Debug.Log("Fire"+ gameObject.name);
    }
}
