using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffArmor : MonoBehaviour
{
    [SerializeField] ChangePlaceCharacter changePlaceCharacter;
    [SerializeField] private int plusArmor;

    [SerializeField] private GameObject armorAnim;

    public void PlusArmor()
    {
        if (changePlaceCharacter.curPlace != null)
        {
            GameObject buff = Instantiate(armorAnim, changePlaceCharacter.curPlace);
            changePlaceCharacter.curPlace.gameObject.GetComponent<CharacterStats>().curArmor += plusArmor;
            changePlaceCharacter.DeclainChange();
            Destroy(buff, 2f);
        }
    }
}
