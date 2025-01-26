using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForHit : MonoBehaviour
{
    private IEnumerator attackMove;
    private IEnumerator backMove;

    public int attackerNumber;
    public GameObject curAttacker;
    public GameObject curDefender;

    private float distance;

    void Start()
    {
        attackMove = AttackMoving();
        backMove = BackMoving();
    }

    IEnumerator AttackMoving()
    {
        while (true)
        {
            Attakking();
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator BackMoving()
    {
        while (true)
        {
            Backing();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void Attakking() //Движение персонажа вперёд для атаки
    {
        if (attackerNumber < SequenceOfMove.Instance.movesList.Count)
        {
            curAttacker = SequenceOfMove.Instance.movesList[attackerNumber];

            if(curAttacker.tag == "Enemy")
            {
                curDefender = StartFight.Instance.curPlayer.gameObject;
            }
            else if(curAttacker.tag == "Character")
            {
                curDefender = StartFight.Instance.curEnemy.gameObject;
            }

            if (SequenceOfMove.Instance.movesList[attackerNumber].GetComponent<EffectsList>().isStun == false)
            {
                curAttacker.transform.position = Vector2.MoveTowards(curAttacker.transform.position, curDefender.transform.position, 0.1f);
                distance = Vector2.Distance(curAttacker.transform.position, curDefender.transform.position);    
            }
            else
            {
                PlusAttackNumber();
                if (attackerNumber < SequenceOfMove.Instance.movesList.Count)
                {
                    StartFight.Instance.OneMove();
                }
                else
                {
                    StopAttack();
                    EndTurn();
                }
            }
        }
        else
        {
            attackerNumber = 0;
        }
    }

    private void Backing() //Отступление персонажа на начальную точку
    {
        curAttacker.transform.position = Vector2.MoveTowards(curAttacker.transform.position, curAttacker.GetComponent<PositionHolder>().posObject.position, 0.1f);

        distance = Vector2.Distance(curAttacker.transform.position, curAttacker.GetComponent<PositionHolder>().posObject.position);

        if(distance < 0.1f)
        {
            curAttacker.transform.position = curAttacker.GetComponent<PositionHolder>().posObject.position;
            StopBacking();
            PlusAttackNumber();
            if(attackerNumber < SequenceOfMove.Instance.movesList.Count)
            {
                StartFight.Instance.OneMove();
            }
            else
            {
                EndTurn();
            }
        }
    }


    public void StartBacking()
    {
        StartCoroutine(backMove);
    }
    public void StopBacking()
    {
        StopCoroutine(backMove);
    }


    public void StartAttack()
    {
        StartCoroutine(attackMove);
    }

    public void StopAttack()
    {
        StopCoroutine(attackMove);
    }

    public void PlusAttackNumber()
    {
        attackerNumber++;
    }

    public void EndTurn() //Срабатывание эффектов в конце хода
    {
        PoisonDamage.Instance.TakePoisonDamage();
        BleedDamage.Instance.TakeBleedDamage();
        AllCurrentEffect.Instance.TimeDown();
    }
}
