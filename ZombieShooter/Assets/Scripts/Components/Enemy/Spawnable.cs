using UnityEngine;

public class Spawnable : PooledMonoBehaviour {
    [SerializeField] public float returnToPoolDelay = 10f;
    public Health health;
    private void Start()
    {
        health = GetComponent<Health>();
        if (health != null) {
            health.OnDied += Health_OnDied;
        }
    }

    private void Health_OnDied()
    {
        ReturnToPool(returnToPoolDelay);
    }

    private void OnDestroy()
    {
        health.OnDied -= Health_OnDied;
    }
}
