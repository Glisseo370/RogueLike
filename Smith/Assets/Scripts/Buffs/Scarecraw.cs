using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecraw : MonoBehaviour
{
    [SerializeField] private GameObject extraPlace;
    [SerializeField] private GameObject scareCraw;

    public void CallScareCraw()
    {
        if(extraPlace.transform.childCount == 0)
        {
            Instantiate(scareCraw, extraPlace.transform);
            PlayerCharacterList.Instance.playerCharacter.Clear();
            GameObject[] players;
            players = GameObject.FindGameObjectsWithTag("Character");

            for(int i = 0; i < players.Length; i++)
            {
                PlayerCharacterList.Instance.playerCharacter.Add(players[i]);
            }
        }

        PlayerCharacterList.Instance.ChangeListPlayer();
    }
}
