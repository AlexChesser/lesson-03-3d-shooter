﻿using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float projectileSpeed = 40f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float maxDistance = 100f;

    private Camera _camera;

    private RaycastHit hitInfo;
    private void Start()
    {
        _camera = Camera.main;
    }

    protected override void WeaponFired()
    {
        Vector3 direction = GetDirection();
        var projectile = projectilePrefab.Get<Projectile>(weapon.BarrelEnd.position, Quaternion.Euler(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
    }

    private Vector3 GetDirection()
    {
        var ray = _camera.ViewportPointToRay(Vector3.one / 2f);
        Vector3 target = ray.GetPoint(300f);
        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            target = hitInfo.point;
        }
        Vector3 direction = target - weapon.BarrelEnd.position;
        direction.Normalize();
        return direction;
    }
}
