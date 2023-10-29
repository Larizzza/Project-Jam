using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float limite, posInicial;
    private Transform cam;
    public float efeitoPara;

    void Start(){
        posInicial = transform.position.x;
        limite = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    void Update(){
        float rePos = cam.transform.position.x * (1 - efeitoPara);
        float distancia = cam.transform.position.x * efeitoPara;
        transform.position = new Vector3 (posInicial + distancia, transform.position.y, transform.position.z);

        if(rePos > posInicial + limite){
            posInicial += limite;
        } else if (rePos < posInicial - limite){
            posInicial -= limite;
        }
    }
}
