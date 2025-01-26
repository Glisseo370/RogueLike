using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterList : MonoBehaviour
{
    public static EnemyCharacterList Instance {  get; private set; }

    public List<GameObject> enemyCharacter = new List<GameObject>();

    [SerializeField] private MovingForHit movingForHit;

    private void Awake()
    {
        Instance = this;

        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemyCharacter.Add(enemies[i]);
            }
        }
    }

    public void DeleteOne()
    {
        for (int i = 0; i < SequenceOfMove.Instance.movesList.Count; i++)
        {
            if (SequenceOfMove.Instance.movesList[i] == enemyCharacter[0])
            {
                if(i <= movingForHit.attackerNumber)
                {
                    movingForHit.attackerNumber--;
                }
                SequenceOfMove.Instance.movesList.RemoveAt(i);
            }
        }
        enemyCharacter.RemoveAt(0);
        ChangeListEnemy();
        if(movingForHit.attackerNumber < 0)
        {
            movingForHit.attackerNumber = 0;
        }
    }

    public void ChangeListEnemy()
    {
        enemyCharacter.Sort((enemy1, enemy2) => enemy1.transform.position.x.CompareTo(enemy2.transform.position.x));
        enemyCharacter.Reverse();
    }
}
