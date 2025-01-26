using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedHit : MonoBehaviour
{
    [SerializeField] private MovingForHit movingForHit;
    [SerializeField] private GameObject buffIcon;
    public void Bleed()
    {
        if (movingForHit.curDefender != null)
        {
            movingForHit.curDefender.gameObject.GetComponent<EffectsList>().isBleed = true;
            Instantiate(buffIcon, movingForHit.curDefender.GetComponent<PositionHolder>().posBuff);
        }
    }

    public void HowMuchBleed()
    {
        movingForHit.curDefender.gameObject.GetComponent<CharacterStats>().bleedDamageTake = movingForHit.curAttacker.gameObject.GetComponent<CharacterStats>().bleedDamageDeal;
    }

    public void RollBleed()
    {
        if (movingForHit.curAttacker.gameObject.GetComponent<CharacterStats>().bleedChance > 0 && movingForHit.curDefender.gameObject.GetComponent<EffectsList>().isBleed == false && movingForHit.curDefender.gameObject.GetComponent<CharacterStats>().curArmor <= 0)
        {
            int roll = Random.Range(1, 101);
            if (roll < movingForHit.curAttacker.gameObject.GetComponent<CharacterStats>().bleedChance)
            {
                Bleed();
                HowMuchBleed();
            }
        }
    }
}
