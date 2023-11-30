using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boss_base : MonoBehaviour
{
    public int vida = 1000;
    public bool estaImune = false;
    private float tempoImune = 0f;
    public float intervalo = 5f;
    public float duracaoImune = 2.5f;
    public GameObject invulneravel;

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
            invulneravel.SetActive(true);
        } else {
            invulneravel.SetActive(false);
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
                SceneManager.LoadScene("win");
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
