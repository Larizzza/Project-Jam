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
    public float tempoBalanço = 10f;  
    public float duracaoBalanço = 3f;
    private bool acionado = false;
    public GameObject boss;
    private int saudeInicial;
    private float tempoDesdeUltimoBalanço = 0f;  
    private Animator bossAnimator;
    public GameObject aviso;
    private bool avisoAtivado = false;

    void Start(){
        saudeInicial = boss.GetComponent<boss_base>().vida;
        bossAnimator = boss.GetComponent<Animator>();
    }

    void Update(){
        if (boss.GetComponent<boss_base>().vida <= saudeInicial / 2 && !avisoAtivado){
            aviso.SetActive(true);
            acionado = true;
            bossAnimator.SetBool("50cent", true);
            StartCoroutine(DesativarAviso());
            avisoAtivado = true;
        }

        if (acionado){
            plataforma1.transform.position = Vector3.MoveTowards(plataforma1.transform.position, posicaoAlvo1, velocidade * Time.deltaTime);
            plataforma2.transform.position = Vector3.MoveTowards(plataforma2.transform.position, posicaoAlvo2, velocidade * Time.deltaTime);
        }
    }

    IEnumerator DesativarAviso(){
        yield return new WaitForSeconds(4);
        aviso.SetActive(false);
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
