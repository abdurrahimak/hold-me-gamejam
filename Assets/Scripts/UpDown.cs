using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float UpDownTreshold = 2f;
    public float Speed = 1f;
    private Vector3 defaultPosition;
    private bool up = true;
    void Start()
    {
        defaultPosition = transform.position;
    }


    void Update()
    {
        if (up)
        {
            if (transform.position.y > (defaultPosition.y + UpDownTreshold))
            {
                up = false;
            }
            else
            {
                transform.position += (Vector3.up * Time.deltaTime * Speed);
            }
        }
        else
        {
            if (transform.position.y < (defaultPosition.y - UpDownTreshold))
            {
                up = true;
            }
            else
            {
                transform.position -= (Vector3.up * Time.deltaTime * Speed);
            }
        }
    }
}
