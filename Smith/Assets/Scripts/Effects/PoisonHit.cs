using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHit : MonoBehaviour
{
    [SerializeField] private MovingForHit movingForHit;
    [SerializeField] private GameObject buffIcon;
    public void Poison()
    {
        if (movingForHit.curDefender != null)
        {
            movingForHit.curDefender.gameObject.GetComponent<EffectsList>().isPoison = true;
            Instantiate(buffIcon, movingForHit.curDefender.GetComponent<PositionHolder>().posBuff);
        }
    }

    public void HowMuchPoison()
    {
        movingForHit.curDefender.gameObject.GetComponent<CharacterStats>().poisonDamageTake = movingForHit.curAttacker.gameObject.GetComponent<CharacterStats>().poisonDamageDeal;
    }

    public void RollPoison()
    {
        if (movingForHit.curAttacker.gameObject.GetComponent<CharacterStats>().poisonChance > 0 && movingForHit.curDefender.gameObject.GetComponent<EffectsList>().isPoison == false)
        {
            int roll = Random.Range(1, 101);
            if (roll < movingForHit.curAttacker.gameObject.GetComponent<CharacterStats>().poisonChance)
            {
                Poison();
                HowMuchPoison();
            }
        }
    }
}
