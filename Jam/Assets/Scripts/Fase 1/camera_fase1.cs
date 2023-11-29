using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_fase1 : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 5.0f; 
    

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
