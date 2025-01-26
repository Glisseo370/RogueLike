using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterList : MonoBehaviour
{
    public static PlayerCharacterList Instance { get; private set; }

    public List<GameObject> playerCharacter = new List<GameObject>();

    [SerializeField] private MovingForHit movingForHit;

    private void Awake()
    {
        Instance = this;

        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Character");

        if(players.Length > 0)
        {
            for(int i = 0; i < players.Length; i++)
            {
                playerCharacter.Add(players[i]);
            }
        }
    }

    public void DeleteOne() //Удаление персонажа после смерти
    {
        for(int i = 0;i < SequenceOfMove.Instance.movesList.Count; i++)
        {
            if(SequenceOfMove.Instance.movesList[i] == playerCharacter[0])
            {
                if(i <= movingForHit.attackerNumber)
                {
                    movingForHit.attackerNumber--;
                }
                SequenceOfMove.Instance.movesList.RemoveAt(i);
            }
        }

        playerCharacter.RemoveAt(0);
        ChangeListPlayer();
        if (movingForHit.attackerNumber < 0)
        {
            movingForHit.attackerNumber = 0;
        }
    }

    public void ChangeListPlayer()
    {
        playerCharacter.Sort((player1, player2) => player1.transform.position.x.CompareTo(player2.transform.position.x));
        playerCharacter.Reverse();
    }
}
