using System.Collections;
using UnityEngine;

public class controle_anim_boss : MonoBehaviour
{
    public Animator animador;
    public int vidaMaxima = 100;
    public int vidaAtual;
    public string atacando = "attack";
    public string parada = "idle";
    public string puta = "50cent";

    void Start()
    {
        vidaAtual = vidaMaxima;
        animador.Play(atacando);
        StartCoroutine(AtaqueACadaPoucosSegundos(8));
    }

    void Update()
    {
        if (vidaAtual <= vidaMaxima / 2)
        {
            animador.runtimeAnimatorController = null;
            animador.Play(puta);
        }
    }

    IEnumerator AtaqueACadaPoucosSegundos(int segundos)
    {
        while (true)
        {
            yield return new WaitForSeconds(segundos);
            animador.Play(atacando);
            yield return new WaitForSeconds(animador.GetCurrentAnimatorStateInfo(0).length);
            animador.Play(vidaAtual <= vidaMaxima / 2 ? puta : parada);
        }
    }

    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;
    }
}
