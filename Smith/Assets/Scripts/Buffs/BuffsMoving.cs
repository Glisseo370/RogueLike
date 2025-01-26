using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsMoving : MonoBehaviour
{
    private IEnumerator moveForward;

    [SerializeField] private GameObject[] buffsIcons;
    [SerializeField] private Transform[] buffsPlace;
    [SerializeField] private Transform backPlace;

    [SerializeField] private BuffsMoving[] otherBuffs;

    public bool hide = true;

    private void Start()
    {
        moveForward = movingForward();
    }

    IEnumerator movingForward()
    {
        while (true)
        {
            ForwardMove();
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void ForwardMove()
    {
        float distance;
        if(hide == true)
        {
            HideOtherBuffs();
            for (int i = 0; i < buffsIcons.Length; i++)
            {
                buffsIcons[i].transform.position = Vector2.MoveTowards(buffsIcons[i].transform.position, buffsPlace[i].position, 10f);
            }
            distance = Vector2.Distance(buffsIcons[0].transform.position, buffsPlace[0].position);
            if(distance < 0.1f)
            {
                hide = false;
                StopMovingIcons();
            }
        }
        else
        {
            HideOtherBuffs();
            for (int i = 0; i < buffsIcons.Length; i++)
            {
                buffsIcons[i].transform.position = Vector2.MoveTowards(buffsIcons[i].transform.position, backPlace.position, 10f);
            }
            distance = Vector2.Distance(buffsIcons[0].transform.position, backPlace.position);
            if (distance < 0.1f)
            {
                hide = true;
                StopMovingIcons();
            }
        }
        
    }

    public void StartMovingIcons()
    {
        StartCoroutine(moveForward);
    }

    public void StopMovingIcons()
    {
        StopCoroutine(moveForward);
    }

    private void HideOtherBuffs()
    {
        if (otherBuffs != null)
        {
            for (int i = 0; i < otherBuffs.Length; i++)
            {
                if (otherBuffs[i].hide == false)
                {
                    otherBuffs[i].StartMovingIcons();
                }
            }
        }
    }
}
