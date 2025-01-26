using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRune : MonoBehaviour
{
    [SerializeField] private GameObject rune;
    [SerializeField] private float speedRotate;

    private void Update()
    {
        if(rune != null)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                rune.transform.Rotate(Vector3.forward * speedRotate);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                rune.transform.Rotate(-Vector3.forward * speedRotate);
            }
        }
    }

    public void SetPeaceOfRune(GameObject peace)
    {
        rune = peace;
    }
}
