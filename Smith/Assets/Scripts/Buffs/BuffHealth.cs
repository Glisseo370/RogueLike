using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffHealth : MonoBehaviour
{
    [SerializeField] ChangePlaceCharacter changePlaceCharacter;
    [SerializeField] private int plusHealth;

    [SerializeField] private GameObject healAnim;

    public void PlusHealth()
    {
        if(changePlaceCharacter.curPlace != null)
        {
            GameObject buff = Instantiate(healAnim, changePlaceCharacter.curPlace);
            changePlaceCharacter.curPlace.gameObject.GetComponent<CharacterStats>().curHealth += plusHealth;
            changePlaceCharacter.DeclainChange();
            Destroy(buff, 2f);
        }
    }

    public void MassiveHeal()
    {
        for(int i = 0; i < PlayerCharacterList.Instance.playerCharacter.Count; i++)
        {
            PlayerCharacterList.Instance.playerCharacter[i].GetComponent<CharacterStats>().curHealth += plusHealth;
            GameObject buff = Instantiate(healAnim, PlayerCharacterList.Instance.playerCharacter[i].transform);
            Destroy(buff, 2f);
        }
    }
}
