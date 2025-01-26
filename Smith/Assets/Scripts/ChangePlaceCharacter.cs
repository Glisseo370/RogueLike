using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangePlaceCharacter : MonoBehaviour
{

    public Transform curPlace;
    [SerializeField] private Vector2 oldPlace;
    [SerializeField] private Transform newPlace;

    private GameObject chooseArrow;


    public void ChangePosition(Transform playerPosition)
    {
        if (curPlace == null)
        {
            curPlace = playerPosition;
            oldPlace = curPlace.position;
            chooseArrow = playerPosition.Find("Arrow").gameObject;
            chooseArrow.SetActive(true);
            return;
        }
        else
        {
            chooseArrow.SetActive(false);
            newPlace = playerPosition;
            
            curPlace.position = newPlace.position;
            newPlace.position = oldPlace;
            curPlace = null;
        }
    }

    public void DeclainChange()
    {
        chooseArrow.SetActive(false);
        curPlace = null;
    }
}
