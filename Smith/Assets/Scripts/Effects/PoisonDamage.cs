using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PoisonDamage : MonoBehaviour
{
    public static PoisonDamage Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void CharacterTakePoisonDamage()
    {
        for(int i = 0; i < PlayerCharacterList.Instance.playerCharacter.Count; i++)
        {
            if (PlayerCharacterList.Instance.playerCharacter[i].GetComponent<EffectsList>().isPoison == true)
            {
                PlayerCharacterList.Instance.playerCharacter[i].GetComponent<CharacterStats>().curHealth -= PlayerCharacterList.Instance.playerCharacter[i].GetComponent<CharacterStats>().poisonDamageTake;
            }
            else
            {
                break;
            }
            if(PlayerCharacterList.Instance.playerCharacter[i].GetComponent<CharacterStats>().curHealth <= 0)
            {
                PlayerCharacterList.Instance.playerCharacter.RemoveAt(i);
                PlayerCharacterList.Instance.ChangeListPlayer();
                SequenceOfMove.Instance.NewMoveList();
            }
        }
    }

    private void EnemyTakePoisonDamage()
    {
        for (int i = 0; i < EnemyCharacterList.Instance.enemyCharacter.Count; i++)
        {
            if (EnemyCharacterList.Instance.enemyCharacter[i].GetComponent<EffectsList>().isPoison == true)
            {
                EnemyCharacterList.Instance.enemyCharacter[i].GetComponent<CharacterStats>().curHealth -= EnemyCharacterList.Instance.enemyCharacter[i].GetComponent<CharacterStats>().poisonDamageTake;
            }
            else
            {
                break;
            }
            if (EnemyCharacterList.Instance.enemyCharacter[i].GetComponent<CharacterStats>().curHealth <= 0)
            {
                EnemyCharacterList.Instance.enemyCharacter.RemoveAt(i);
                EnemyCharacterList.Instance.ChangeListEnemy();
                SequenceOfMove.Instance.NewMoveList();
            }
        }
    }

    public void TakePoisonDamage()
    {
        CharacterTakePoisonDamage();
        EnemyTakePoisonDamage();
    }
}
