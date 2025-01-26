using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SequenceOfMove : MonoBehaviour
{
    public static SequenceOfMove Instance { get; private set; }

    public List<GameObject> movesList = new List<GameObject>();

    private void Start()
    {
        Instance = this;
        NewMoveList();
    }

    public void NewMoveList() //Очерёдность ходов в зависимости от инициации
    {
        movesList = EnemyCharacterList.Instance.enemyCharacter.Concat(PlayerCharacterList.Instance.playerCharacter).ToList();
        movesList.Sort((character1, character2) => character1.GetComponent<CharacterStats>().initiative.CompareTo(character2.GetComponent<CharacterStats>().initiative));
        movesList.Reverse();
    }
}
