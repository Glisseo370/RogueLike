using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Descriptions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject descImage;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private string description;
    public void OnPointerEnter(PointerEventData eventData)
    {
        descText.text = description;
        descImage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descImage.SetActive(false);
    }
}
