using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float projectileSpeed = 40f;
    [SerializeField] private Transform start;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float maxDistance;

    

    private RaycastHit hitInfo;

    private void Start()
    {
        if (start == null)
        {
            start = transform;
        }
    }

    protected override void WeaponFired()
    {
        Vector3 direction = weapon.IsInAimMode ? GetDirection() : start.forward;
        Debug.Log($"projectile direction: {direction} - {Quaternion.LookRotation(direction)} - {transform.position}");
        var projectile = projectilePrefab.Get<Projectile>(transform.position, Quaternion.LookRotation(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
    }

    private Vector3 GetDirection()
    {
        var ray = weapon.Camera.ViewportPointToRay(Vector3.one / 2f);
        Vector3 target = ray.GetPoint(300f);
        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            target = hitInfo.point;
        }
        Vector3 direction = target - transform.position;
        direction.Normalize();
        return direction;
    }
}
