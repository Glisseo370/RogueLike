using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureFix : MonoBehaviour
{
    [SerializeField] private float minTemperature;
    [SerializeField] private float maxTemperature;
    [SerializeField] private float forgingTime;
    [SerializeField] private Slider tempSlider;
    [SerializeField] private Button nextStep;

    [SerializeField] private bool startFix = false;
    [SerializeField] private float timer;
    [SerializeField] private float timerWrongTemperature;

    [SerializeField] private TemperatureLevel temperatureLevel;



    public float armorDurability;

    private void Start()
    {
        nextStep.interactable = false;
    }

    private void Update()
    {
        if (startFix)
        {
            timer += Time.deltaTime;

            if (tempSlider.value < minTemperature || tempSlider.value > maxTemperature)
            {
                timerWrongTemperature += Time.deltaTime;
            }

            if (timer > forgingTime)
            {
                startFix = false;
                nextStep.interactable = true;
                timer = 0f;
                temperatureLevel.StopForging();
            }
        }
    }
    public void StartCheckTemp()
    {
        startFix = true;
    }

    private void OnEnable()
    {
        nextStep.interactable = false;
        startFix = false;
        timer = 0f;
        timerWrongTemperature = 0f;
    }
}

