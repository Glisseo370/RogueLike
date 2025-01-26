using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAttack : MonoBehaviour
{
    [SerializeField] ChangePlaceCharacter changePlaceCharacter;
    [SerializeField] private int plusAttack;

    [SerializeField] private GameObject attackAnim;

    public void PlusAttack()
    {
        if (changePlaceCharacter.curPlace != null)
        {
            GameObject buff = Instantiate(attackAnim, changePlaceCharacter.curPlace);
            changePlaceCharacter.curPlace.gameObject.GetComponent<CharacterStats>().attack += plusAttack;
            changePlaceCharacter.DeclainChange();
            Destroy(buff, 2f);
        }
    }

    public void MassivePlusAttack()
    {
        for (int i = 0; i < PlayerCharacterList.Instance.playerCharacter.Count; i++)
        {
            PlayerCharacterList.Instance.playerCharacter[i].GetComponent<CharacterStats>().attack += plusAttack;
            GameObject buff = Instantiate(attackAnim, PlayerCharacterList.Instance.playerCharacter[i].transform);
            Destroy(buff, 2f);
        }
    }
}
