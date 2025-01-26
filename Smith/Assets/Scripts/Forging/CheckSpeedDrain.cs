using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CheckSpeedDrain : MonoBehaviour
{
    [SerializeField] private float[] checkStage;
    [SerializeField] private int curStage;


    [SerializeField] private Slider sliderDrain;

    [SerializeField] private float timer;
    [SerializeField] private float rightTime;
    [SerializeField] private float sumDifTime;

    [SerializeField] private bool startDrain;

    [SerializeField] private Button nextStep;

    private void Update()
    {
        if(startDrain == true)
        {
            timer += Time.deltaTime;
        }
    }

    public void Draining()
    {
        if(sliderDrain.value < sliderDrain.maxValue)
        {
            startDrain = true;
            if(sliderDrain.value == checkStage[curStage])
            {
                if(curStage < checkStage.Length)
                {
                    float difTime = Math.Abs(timer - rightTime);
                    Debug.Log(difTime);
                    sumDifTime += difTime;
                }
                curStage++;
                timer = 0;
            }
        }
        else
        {
            nextStep.interactable = true;
            startDrain = false;
            if(curStage != checkStage.Length)
            {
                sumDifTime = 4;
            }
        }
    }

    private void OnEnable()
    {
        nextStep.interactable = false;
        timer = 0;
        sumDifTime = 0;
        curStage = 0;
        startDrain = false;
        sliderDrain.value = 0;
    }
}
