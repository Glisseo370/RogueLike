using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceForHitSword : MonoBehaviour
{
    [SerializeField] private Slider sliderHit;
    [SerializeField] private Button[] buttonsHit;
    [SerializeField] private Button sword;

    [SerializeField] private float maxTimer;
    [SerializeField] private float timer;
    [SerializeField] private bool canHit = false;

    [SerializeField] private int hitCount;
    [SerializeField] private int maxHitCount;

    [SerializeField] private Button curPlaceHit;
    [SerializeField] private int curNumberPlace;

    [SerializeField] private Button startHitButton;
    [SerializeField] private Button nextStep;

    private void Update()
    {
        if(canHit == true)
        {
            timer += Time.deltaTime;
            startHitButton.interactable = false;
        }

        if(timer >= maxTimer && curPlaceHit == null)
        {
            int roll = Random.Range(0, buttonsHit.Length);
            curNumberPlace = roll;
            buttonsHit[roll].gameObject.SetActive(true);
            sword.interactable = true;
            curPlaceHit = buttonsHit[roll];
            timer = 0;
        }
        else if(timer >= maxTimer && curPlaceHit != null)
        {
            Hit();
        }
    }
    private void OnEnable()
    {
        nextStep.interactable = false;
        startHitButton.interactable = true;
        sword.interactable = false;
        timer = 0;
        sliderHit.value = 0;
        hitCount = 0;
    }

    public void StartHit()
    {
        canHit = true;
    }

    public void RightHit()
    {
        sliderHit.value += 1;
        Hit();
    }

    public void WrongHit()
    {
        Hit();
    }

    private void Hit()
    {
        sword.interactable = false;
        hitCount++;
        buttonsHit[curNumberPlace].gameObject.SetActive(false);
        curPlaceHit = null;
        timer = 0;
        if (hitCount >= maxHitCount)
        {
            nextStep.interactable = true;
            canHit = false;
        }
    }
}
