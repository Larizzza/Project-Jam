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
    private float targetY; // Posição Y alvo para interpolação

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
                // Define a posição Y alvo para a interpolação
                targetY = ch.transform.position.y - speed;
                // Interpola a posição Y do chão para a posição Y alvo
                ch.transform.position = new Vector3(ch.transform.position.x, Mathf.Lerp(ch.transform.position.y, targetY, Time.deltaTime), ch.transform.position.z);
                if (ch.transform.position.y <= posicaoLimite) {
                    Destroy(ch);
                    controlaEfeitos.GetComponent<Efeitos>().StopSound();
                }
            }
            yield return null;
        }
    }
}
