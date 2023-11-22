using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_base : MonoBehaviour
{
    public int vida = 1000;
    public bool estaImune = false;
    private float tempoImune = 0f;
    private float intervalo = 3f;
    public Text textoImune;

    void Start(){
    }

    void Update(){
        tempoImune += Time.deltaTime;
        if (tempoImune >= intervalo){
            estaImune = !estaImune;
            tempoImune = 0f;
        }

        if (estaImune){
            textoImune.text = "Boss está imune!";
        } else {
            textoImune.text = "";
        }
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
