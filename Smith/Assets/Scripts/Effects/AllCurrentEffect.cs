using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCurrentEffect : MonoBehaviour
{
    public static AllCurrentEffect Instance { get; private set; }

    [SerializeField] private List<GameObject> effectsList = new List<GameObject>();


    private void Start()
    {
        Instance = this;
    }

    public void SeekEffect()
    {
        GameObject[] effects = GameObject.FindGameObjectsWithTag("Effect");
        if(effects.Length > 0)
        {
            for(int i = 0; i < effects.Length; i++)
            {
                effectsList.Add(effects[i]);
            }
        }
    }

    public void TimeDown()
    {
        if(effectsList.Count > 0)
        {
            for (int i = 0;i < effectsList.Count; ++i)
            {
                if(effectsList[i] != null)
                {
                    effectsList[i].GetComponent<BuffsSO>().timeLife -= 1;
                    if (effectsList[i].GetComponent<BuffsSO>().timeLife <= 0)
                    {
                        effectsList[i].GetComponent<BuffsSO>().EndBuff();
                    }
                }
            }           
        }
        effectsList.Clear();

    }
}
