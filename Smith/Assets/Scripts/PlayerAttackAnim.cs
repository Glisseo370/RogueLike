using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnim : MonoBehaviour
{

    [SerializeField] private MovingForHit movingForHit;
    private CriticalHit criticalHit;

    private Animator animator;

    private void Start()
    {
        criticalHit = GetComponentInParent<CriticalHit>();
        animator = GetComponent<Animator>();
    }

    public void AttackAnim() //�������� ����� + ������� �����/��������� ��������
    {
        animator.SetTrigger("Attack");
    }
    public void StartAttack()
    {
        criticalHit.RollCrit();
        StartFight.Instance.HitFromPlayer();
    }

    public void BackAnim()
    {
        if(gameObject.GetComponentInParent<EffectsList>().isCriticalHit == true)
        {
            criticalHit.CritOff();
        }
        movingForHit.StartBacking();
    }
}
