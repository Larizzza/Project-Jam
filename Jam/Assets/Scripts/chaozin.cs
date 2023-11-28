using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class chaozin : MonoBehaviour
{
    public boss_base boss;
    private GameObject[] chao;
    public float speed = 0.01f;
    public Text avisoTexto; 
    private bool mensagemMostrada = false; 
    public GameObject controlaEfeitos;
    public float posicaoLimite;

    void Update(){
        if (boss.vida <= 300){
            StartCoroutine(LowerFloor());
            controlaEfeitos.GetComponent<Efeitos>().PlayRandomDashSound();
        }
    }

    IEnumerator LowerFloor(){
        chao = GameObject.FindGameObjectsWithTag("chao");

        if (!mensagemMostrada) { 
            avisoTexto.text = "A vida do boss atingiu 30%, o chão irá descer lentamente. Por favor utilize as plataformas.";
            yield return new WaitForSeconds(10);
            avisoTexto.text = "";
            mensagemMostrada = true; 
        }

        while (true){
            foreach (GameObject ch in chao){
                ch.transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
                if (ch.transform.position.y <= posicaoLimite) {
                    Destroy(ch);
                    controlaEfeitos.GetComponent<Efeitos>().StopSound();
                }
            }
            yield return null;
        }
    }
}
