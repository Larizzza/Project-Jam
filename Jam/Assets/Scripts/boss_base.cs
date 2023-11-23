using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_base : MonoBehaviour
{
    public int vida = 1000;
    public bool estaImune = false;
    private float tempoImune = 0f;
    public float intervalo = 5f;
    public float duracaoImune = 2.5f;
    public Text textoImune;

    void Start(){
    }

    void Update(){
        tempoImune += Time.deltaTime;
        if (tempoImune >= intervalo){
            estaImune = !estaImune;
            tempoImune = 0f;
            if (estaImune){
                StartCoroutine(DesativarImunidade());
            }
        }

        if (estaImune){
            textoImune.text = "Boss está imune!";
        } else {
            textoImune.text = "";
        }
    }

    IEnumerator DesativarImunidade(){
        yield return new WaitForSeconds(duracaoImune);
        estaImune = false;
    }

    public void ReceberDano(int dano){
        if (!estaImune){
            vida -= dano;
            if (vida <= 0){
                Morte();
            }
        } else {
            Debug.Log("Imune!");
        }
    }

    void Morte(){
        Debug.Log("Boss morreu!");
        Destroy(gameObject);
    }
}
