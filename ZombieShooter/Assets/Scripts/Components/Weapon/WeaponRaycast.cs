using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : WeaponComponent
{
    [SerializeField] PooledMonoBehaviour decalPrefab;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit hitInfo;
    private float maxDistance = 300f;

    protected override void WeaponFired()
    {
        var ray = weapon.GetAim();
        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask)) {
            SpawnDecal(hitInfo.point, hitInfo.normal);
        }
    }

    private void SpawnDecal(Vector3 point, Vector3 normal)
    {
        var decal = decalPrefab.Get<PooledMonoBehaviour>(point, Quaternion.LookRotation(-normal));
        decal.ReturnToPool(5f);
    }
}
