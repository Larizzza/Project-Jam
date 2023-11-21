using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_boss : MonoBehaviour
{
    public GameObject plataforma1; 
    public GameObject plataforma2; 
    public Vector3 posicaoAlvo1; 
    public Vector3 posicaoAlvo2; 
    public float velocidade = 1f;
    private bool acionado = false;
    public GameObject boss;
    private int initialBossHealth;

    void Start(){
        initialBossHealth = boss.GetComponent<boss_base>().vida;
    }

    void Update(){
        if (boss.GetComponent<boss_base>().vida <= initialBossHealth / 2){
            acionado = true;
        }

        if (acionado){
            plataforma1.transform.position = Vector3.MoveTowards(plataforma1.transform.position, posicaoAlvo1, velocidade * Time.deltaTime);
            plataforma2.transform.position = Vector3.MoveTowards(plataforma2.transform.position, posicaoAlvo2, velocidade * Time.deltaTime);
                if (plataforma1.transform.position == posicaoAlvo1 && plataforma2.transform.position == posicaoAlvo2){
                    //mensagem avisando que o chão irá desaparecer e o jogador só poderá usar as plataformas
            }
        }
    }
}