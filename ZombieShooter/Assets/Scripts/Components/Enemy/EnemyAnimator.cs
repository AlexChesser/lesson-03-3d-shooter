using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    private Health health;
    private int kHit;
    private int kDie;
    private int kAttack;
    private int kAttackID;
    private EnemyAttack enemyAttack;

    private void Awake()
    {
        kHit = Animator.StringToHash("Hit");
        kDie = Animator.StringToHash("Die");
        kAttack = Animator.StringToHash("Attack");
        kAttackID = Animator.StringToHash("AttackID");
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        health.OnDied += Health_OnDied;
        health.OnTookHit += Health_OnTookHit;
        enemyAttack = GetComponent<EnemyAttack>();
        enemyAttack.OnAttack += EnemyAttack_OnAttack;
    }

    private void EnemyAttack_OnAttack()
    {
        animator.SetInteger(kAttackID, Random.Range(0, 5));
        animator.SetTrigger(kAttack);
    }

    private void Health_OnTookHit()
    {
        animator.SetTrigger(kHit);
    }

    private void Health_OnDied()
    {
        animator.SetTrigger(kDie);
    }

    private void OnDestroy()
    {
        health.OnDied -= Health_OnDied;
        health.OnTookHit -= Health_OnTookHit;
        enemyAttack.OnAttack -= EnemyAttack_OnAttack;
    }
}
