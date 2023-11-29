using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_boss : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 5.0f; 
    public Vector3 offset;
    public Vector3 posicaoPlataforma = new Vector3(0, 1.81f, -10);
    public float tamanhoPlataforma = 6.9f;
    private Camera cam;
    public static bool esta_na_plat;

    void Start(){
        cam = GetComponent<Camera>();
        esta_na_plat = false;
    }

    void LateUpdate(){
        if (target != null){
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            float targetSize = esta_na_plat ? tamanhoPlataforma : 5f;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * smoothSpeed);

            if (!esta_na_plat){
                StartCoroutine(CameraDelay());
            }
        }
    }

    public void SetTarget(Transform newTarget){
        target = newTarget;
    }

    IEnumerator CameraDelay(){
        yield return new WaitForSeconds(5.0f);
        if (!esta_na_plat){
            cam.orthographicSize = 5f;
        }
    }
}
