using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float projectileSpeed = 40f;
    [SerializeField] private Transform start;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float maxDistance;

    private Camera _camera;

    private RaycastHit hitInfo;

    private void Start()
    {
        _camera = Camera.main;
        if (start == null)
        {
            start = transform;
        }
    }

    protected override void WeaponFired()
    {
        Vector3 direction = GetDirection();
        var projectile = projectilePrefab.Get<Projectile>(transform.position, Quaternion.Euler(transform.forward));
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
        Vector3 direction = target - transform.position;
        direction.Normalize();
        return direction;
    }
}
