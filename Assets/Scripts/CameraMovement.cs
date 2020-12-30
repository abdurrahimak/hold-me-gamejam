using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform FollowTransform;
    private float diff;
    void Start()
    {
        diff = Mathf.Abs(transform.position.z);
    }

    void Update()
    {

    }

    private void LateUpdate()
    {
        if (FollowTransform != null)
        {
            Vector3 targetPos = transform.position;
            targetPos.z = FollowTransform.position.z - diff;
            targetPos.x = FollowTransform.position.x;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 5f);
        }
    }
}
