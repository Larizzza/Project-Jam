using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera : MonoBehaviour
{
   public GameObject player;
   private Vector3 deslocamento;

    void Start()
    {
        deslocamento = transform.position - player.transform.position;
    }

    
    void LateUpdate()
    {
        transform.position = player.transform.position + deslocamento;
    }
}
