using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaozin : MonoBehaviour
{
    public boss_base boss;
    private GameObject[] chao;
    public float speed = 0.01f;

    void Update(){
        if (boss.vida <= 300){
            StartCoroutine(LowerFloor());
        }
    }

    IEnumerator LowerFloor(){
        chao = GameObject.FindGameObjectsWithTag("chao");

            while (true){
            foreach (GameObject ch in chao){
                ch.transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
                if (ch.transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - 1){
                    Destroy(ch);
                }
            }

            yield return null;
        }
    }
}
