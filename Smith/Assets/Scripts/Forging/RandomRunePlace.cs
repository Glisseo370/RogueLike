using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRunePlace : MonoBehaviour
{
    [SerializeField] private Transform[] peaceOfRune;

    private void Start()
    {
        for(int i = 0; i < peaceOfRune.Length; i++)
        {
            int roll = Random.Range(-36, 37);
            peaceOfRune[i].transform.localRotation = Quaternion.Euler(0f, 0f, roll * 10);
        }
    }
}
