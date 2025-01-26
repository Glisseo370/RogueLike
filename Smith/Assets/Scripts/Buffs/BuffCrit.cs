using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuffCrit : MonoBehaviour
{
    [SerializeField] ChangePlaceCharacter changePlaceCharacter;

    [SerializeField] private GameObject critAnim;

    [SerializeField] private GameObject buffIcon;
    public void PlusCrit()
    {
        if (changePlaceCharacter.curPlace != null)
        {
            GameObject buff = Instantiate(critAnim, changePlaceCharacter.curPlace);
            changePlaceCharacter.curPlace.gameObject.GetComponent<EffectsList>().isCriticalHit = true;

            Instantiate(buffIcon, changePlaceCharacter.curPlace.GetComponent<PositionHolder>().posBuff);
            changePlaceCharacter.curPlace.GetComponent<CriticalHit>().DoubleDamage();

            changePlaceCharacter.DeclainChange();
            Destroy(buff, 2f);
        }
    }
}
