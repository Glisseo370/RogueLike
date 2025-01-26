using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private CharacterStats characterStats;


    private void Update()
    {
        if(characterStats.curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
