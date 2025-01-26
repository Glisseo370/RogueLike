using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    public static StartFight Instance { get; private set; }

    public CharacterStats curPlayer;
    public CharacterStats curEnemy;

    [SerializeField] private MovingForHit movingForHit;

    [SerializeField] private DebuffStun debuffStun;
    [SerializeField] private PoisonHit poisonHit;
    [SerializeField] private BleedHit bleedHit;
    private void Start()
    {
        Instance = this;
    }
    public void OneMove()
    {
        if(curPlayer == null || curEnemy == null)
        {
            CurrentTarget();
        }
        movingForHit.StartAttack();
    }

    public void HitFromPlayer() //Удар игрока
    {
        debuffStun.RollStun();
        poisonHit.RollPoison();
        bleedHit.RollBleed();

        if (curEnemy.curArmor > 0)
        {
            curEnemy.curArmor -= movingForHit.curAttacker.GetComponent<CharacterStats>().attack;
            if (curEnemy.curArmor < 0)
            {
                curEnemy.curHealth += curEnemy.curArmor;
            }
        }
        else
        {
            curEnemy.curHealth -= movingForHit.curAttacker.GetComponent<CharacterStats>().attack;
        }

        if (curEnemy.curHealth <= 0)
        {
            EnemyCharacterList.Instance.DeleteOne();
            if (EnemyCharacterList.Instance.enemyCharacter.Count == 0)
            {
                Debug.Log("Победа");
                SequenceOfMove.Instance.movesList.Clear();
                return;
            }
            CurrentTarget();
        }
    }

    public void HitFromEnemy()
    {
        debuffStun.RollStun();
        poisonHit.RollPoison();
        bleedHit.RollBleed();

        if (curPlayer.curArmor > 0)
        {
            curPlayer.curArmor -= movingForHit.curAttacker.GetComponent<CharacterStats>().attack;
            if (curPlayer.curArmor < 0)
            {
                curPlayer.curHealth += curPlayer.curArmor;
            }
        }
        else
        {
            curPlayer.curHealth -= movingForHit.curAttacker.GetComponent<CharacterStats>().attack;
        }

        if (curPlayer.curHealth <= 0)
        {
            PlayerCharacterList.Instance.DeleteOne();
            if (PlayerCharacterList.Instance.playerCharacter.Count == 0)
            {
                Debug.Log("Поражение");
                SequenceOfMove.Instance.movesList.Clear();
                return;
            }
            CurrentTarget();
        }
    }

    private void CurrentTarget()
    {
        curPlayer = PlayerCharacterList.Instance.playerCharacter[0].GetComponent<CharacterStats>();
        curEnemy = EnemyCharacterList.Instance.enemyCharacter[0].GetComponent<CharacterStats>();
    }
}
