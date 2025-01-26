using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHilt : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private Button runeStep;

    public void Spawn(GameObject hilt)
    {
        GameObject temp;
        temp = Instantiate(hilt, spawnPoint);

        temp.GetComponent<MovingPart>().runeButton = runeStep;
        
    }
}
