using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHit : MonoBehaviour
{
    private CharacterStats characterStats;
    private EffectsList effectsList;
    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        effectsList = GetComponent<EffectsList>();
    }

    public void RollCrit()
    {
        int roll = Random.Range(1, 101);
        if(roll <= characterStats.criticalChance && effectsList.isCriticalHit == false)
        {
            effectsList.isCriticalHit = true;
            DoubleDamage();
        }
    }

    public void CritOff()
    {
        if(effectsList.isCriticalHit == true)
        {
            effectsList.isCriticalHit = false;
            HalfDamage();
        }
    }

    public void DoubleDamage()
    {
        characterStats.attack = characterStats.attack * 2;
    }

    public void HalfDamage()
    {
        characterStats.attack = characterStats.attack / 2;
    }
}
