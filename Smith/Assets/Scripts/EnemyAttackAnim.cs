using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAnim : MonoBehaviour
{

    [SerializeField] private MovingForHit movingForHit;
    private CriticalHit criticalHit;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        criticalHit = GetComponentInParent<CriticalHit>();
    }

    public void AttackAnim()
    {
        animator.SetTrigger("Attack");
    }
    public void StartAttack()
    {
        criticalHit.RollCrit();
        StartFight.Instance.HitFromEnemy();
    }

    public void BackAnim()
    {
        //criticalHit.CritOff();
        movingForHit.StartBacking();
    }
}
