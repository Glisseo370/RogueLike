using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureLevel : MonoBehaviour
{
    [SerializeField] private Slider tempSlider;
    [SerializeField] private Slider upSlider;
    [SerializeField] private float plusTemp;

    private IEnumerator forging;

    private void Start()
    {
        forging = Forging();
    }
    public void Testing()
    {
        Debug.Log("1");
    }

    public void TempUp()
    {
        float curTemp = upSlider.value/1000;
        plusTemp += curTemp;

        if(plusTemp > 10f)
        {
            plusTemp = 10;
        }

        if(curTemp == 0)
        {
            tempSlider.value += plusTemp;
            plusTemp = 0;
        }
        
    }

    IEnumerator Forging()
    {
        while (true)
        {
            tempSlider.value -= 0.1f;
            if (tempSlider.value < 0f)
            {
                tempSlider.value = 0f;
            }
            yield return new WaitForSeconds(0.023f);
        }
    }

    public void StartForging()
    {
        tempSlider.value = 50f;
        StartCoroutine(forging);
    }

    public void StopForging()
    {
        StopCoroutine(forging);
    }

    private void OnEnable()
    {
        tempSlider.value = 0f;
        upSlider.value = 0f;
        plusTemp = 0f;
    }
}
