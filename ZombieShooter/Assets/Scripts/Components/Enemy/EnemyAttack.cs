using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float delayBetweenAttacks = 1.5f;
    [SerializeField] private float maxAttackRange = 1.5f;
    [SerializeField] private float attackDamageDelay = 0.5f;

    private int damage = 1;
    private Health playerHealth;
    private float attackTimer = 0;

    public event Action OnAttack = delegate { };

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (CanAttack()) {
            Attack();
        }
    }

    private bool IsInAttackRange() {
        return Vector3.Distance(transform.position, playerHealth.transform.position) <= maxAttackRange;
    }

    private bool CanAttack()
    {
        
        if (attackTimer > delayBetweenAttacks && IsInAttackRange()) {
            return true;
        }
        return false;
    }

    private void Attack()
    {
        attackTimer = 0;
        OnAttack();
        StartCoroutine(DealDamageAfterDelay());
    }

    private IEnumerator DealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAttacks);
        if (IsInAttackRange()) {
            playerHealth.TakeHit(damage);
        }
    }
}
