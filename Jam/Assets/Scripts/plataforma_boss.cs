using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plataforma_boss : MonoBehaviour
{
    public GameObject plataforma1; 
    public GameObject plataforma2; 
    public Vector3 posicaoAlvo1; 
    public Vector3 posicaoAlvo2; 
    public float velocidade = 1f;
    public float tempoBalanço = 10f;  
    public float duracaoBalanço = 3f;
    private bool acionado = false;
    public GameObject boss;
    private int saudeInicial;
    private float tempoDesdeUltimoBalanço = 0f;  
    public Text avisoTexto;
    private bool mensagemMostrada = false; 

    void Start(){
        saudeInicial = boss.GetComponent<boss_base>().vida;
    }

    void Update(){
        if (boss.GetComponent<boss_base>().vida <= saudeInicial / 2){
            acionado = true;
        }

        if (acionado){
            plataforma1.transform.position = Vector3.MoveTowards(plataforma1.transform.position, posicaoAlvo1, velocidade * Time.deltaTime);
            plataforma2.transform.position = Vector3.MoveTowards(plataforma2.transform.position, posicaoAlvo2, velocidade * Time.deltaTime);
            if (plataforma1.transform.position == posicaoAlvo1 && plataforma2.transform.position == posicaoAlvo2 && !mensagemMostrada){
                StartCoroutine(MostrarAviso());
                mensagemMostrada = true; // a mensagem já foi mostrada
            }

            tempoDesdeUltimoBalanço += Time.deltaTime;
            // Comentei a linha abaixo para remover o efeito de balanço
            // if (tempoDesdeUltimoBalanço >= tempoBalanço){
            //     StartCoroutine(BalançarPlataformas());
            //     tempoDesdeUltimoBalanço = 0f;
            // }
        }
    }

    IEnumerator MostrarAviso(){
        avisoTexto.text = "A vida do boss atingiu 30%, o chão irá descer lentamente. Por favor utilize as plataformas.";
        yield return new WaitForSeconds(10);
        avisoTexto.text = "";
    }

    // A função BalançarPlataformas() ainda está aqui, mas não está sendo chamada
    IEnumerator BalançarPlataformas(){
        float anguloBalanço = 10f;

        Quaternion anguloInicial1 = plataforma1.transform.rotation;
        Quaternion anguloInicial2 = plataforma2.transform.rotation;
        Quaternion anguloAlvo1 = Quaternion.Euler(plataforma1.transform.eulerAngles + new Vector3(0, 0, anguloBalanço));
        Quaternion anguloAlvo2 = Quaternion.Euler(plataforma2.transform.eulerAngles + new Vector3(0, 0, -anguloBalanço));

        float tempo = 0f;
        while (tempo < duracaoBalanço){
            tempo += Time.deltaTime;
            float t = tempo / duracaoBalanço;
            plataforma1.transform.rotation = Quaternion.Lerp(anguloInicial1, anguloAlvo1, t);
            plataforma2.transform.rotation = Quaternion.Lerp(anguloInicial2, anguloAlvo2, t);

            yield return null;
        }
        
        tempo = 0f;
        while (tempo < duracaoBalanço){
            tempo += Time.deltaTime;
            float t = tempo / duracaoBalanço;

            plataforma1.transform.rotation = Quaternion.Lerp(anguloAlvo1, anguloInicial1, t);
            plataforma2.transform.rotation = Quaternion.Lerp(anguloAlvo2, anguloInicial2, t);

            yield return null;
        }
    }
}
