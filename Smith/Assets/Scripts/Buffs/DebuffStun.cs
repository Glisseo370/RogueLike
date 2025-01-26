using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DebuffStun : MonoBehaviour
{
    [SerializeField] private MovingForHit movingForHit;
    [SerializeField] private GameObject buffIcon;
    public void Stun()
    {
        if (movingForHit.curDefender != null)
        {
            movingForHit.curDefender.gameObject.GetComponent<EffectsList>().isStun = true;
            Instantiate(buffIcon, movingForHit.curDefender.GetComponent<PositionHolder>().posBuff);
        }
    }

    public void RollStun()
    {
        Debug.Log("Стан");
        if(movingForHit.curAttacker.gameObject.GetComponent<CharacterStats>().stunChance > 0 && movingForHit.curDefender.gameObject.GetComponent<EffectsList>().isStun == false)
        {
            int roll = Random.Range(1, 101);
            if(roll < movingForHit.curAttacker.gameObject.GetComponent<CharacterStats>().stunChance)
            {
                Stun();
            }
        }
    }
}
