using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGarda : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject nextStep;

    public void Spawn(GameObject garda)
    {
        GameObject gardaHolder;
        gardaHolder = Instantiate(garda, spawnPoint);

        gardaHolder.GetComponent<MovingPart>().nextWindow = nextStep;

    }
}
