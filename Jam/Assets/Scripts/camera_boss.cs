using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_boss : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 5.0f; 
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
