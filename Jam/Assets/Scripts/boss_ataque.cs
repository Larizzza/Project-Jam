using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_ataque : MonoBehaviour
{
    public GameObject[] prefabPedras; // Array de prefabs de pedra
    public Transform[] pontosSpawn; // Array de pontos de spawn
    private float temporizadorDano = 0f;
    private float intervaloDano = 8f;
    [SerializeField] private int quantidadePedras = 3; // Quantidade de pedras por ponto de spawn

    void Update(){
        temporizadorDano += Time.deltaTime;
        if (temporizadorDano >= intervaloDano){
            Murro();
            temporizadorDano = 0f;
        }
    }

    void Murro(){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D colisao){
        if (colisao.gameObject.CompareTag("Teto")){
            SoltarPedras();
        }
    }

    void SoltarPedras(){
        for (int i = 0; i < pontosSpawn.Length; i++){
            for (int j = 0; j < quantidadePedras; j++){
                float deslocamentoX = Random.Range(-10f, 10f);
                float deslocamentoY = Random.Range(-10f, 10f);
                Vector3 posicaoSpawn = pontosSpawn[i].position + new Vector3(deslocamentoX, deslocamentoY, 0);
                Instantiate(prefabPedras[i], posicaoSpawn, pontosSpawn[i].rotation);
            }
        }
    }
}
