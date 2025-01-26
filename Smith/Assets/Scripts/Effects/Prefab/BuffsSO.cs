using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuffsSO : MonoBehaviour
{
    public int timeLife;

    private EffectsList effectList;

    private void Start()
    {
        effectList = GetComponentInParent<EffectsList>();
    }

    public enum TypeOfEffect
    {
        Stun,
        Crit,
        Poison,
        Bleed
    }

    public TypeOfEffect typeOfEffect;

    public void EndBuff()
    {
        switch (typeOfEffect)
        {
            case TypeOfEffect.Stun:
                effectList.isStun = false;
                break;
            case TypeOfEffect.Crit:
                CriticalHit hit = GetComponentInParent<CriticalHit>();
                if(effectList.isCriticalHit == true)
                {
                    hit.CritOff();                
                }
                break;
            case TypeOfEffect.Poison:
                effectList.isPoison = false;
                break;
        }

        Destroy(gameObject);
    }
}
