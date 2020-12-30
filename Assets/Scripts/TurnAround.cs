using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    public float TurnSpeed = 1f;
    public bool PyhsicsEnable = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        euler.y += 360f * Time.deltaTime * TurnSpeed;
        transform.rotation = Quaternion.Euler(euler);
    }
}
