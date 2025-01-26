using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TestingNum : MonoBehaviour
{
    //public int DigitalRoot(long n)
    //{
    //    string numberText = n.ToString();
    //    int number = 0;
    //    foreach (var item in numberText)
    //    {
    //        number = number + item;
    //    }

    //    if(number >= 10)
    //    {
    //        DigitalRoot(number);
    //    }
    //    return 0;
    //}

    public void Numbers(int n)
    {
        string numberText = n.ToString();
        int number = 0;
        foreach (char item in numberText)
        {
            int i = Convert.ToInt32("2");
            Debug.Log(i);
            number = number + i;
            Debug.Log(number);
        }

        //if (number >= 10)
        //{
        //    Debug.Log(number);
        //    Numbers(number);
        //}

    }
}
