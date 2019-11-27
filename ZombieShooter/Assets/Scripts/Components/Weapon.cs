using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private KeyCode hotKey;
    [SerializeField] private float fireDelay = 0.25f;
    [SerializeField] private Transform barrelEnd;

    public Transform BarrelEnd => barrelEnd;
    public KeyCode HotKey => hotKey;
    public event Action OnFire = delegate { };
    public bool IsInAimMode => Input.GetMouseButton(1) == false;

    private float fireTimer = 0f;

    private Camera _camera;
    private WeaponAmmo ammo;


    private void Start()
    {
        _camera = Camera.main;
        ammo = GetComponent<WeaponAmmo>();
    }

    private bool CanFire() {
        if (ammo != null && !ammo.IsAmmoReady()) {
            return false;
        }
        return fireTimer > fireDelay;
    }

    public Ray GetAim() {
        return _camera.ViewportPointToRay(Vector3.one / 2f);
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
