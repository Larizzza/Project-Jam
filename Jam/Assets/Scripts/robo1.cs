using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robo1 : MonoBehaviour
{
    public Animator objetoAnimator; 
    public string animacaoIdle = "Idle"; 
    public string animacaoAtivacao = "AtivarAnimacao"; 

    private bool emIdle = true; 

    void Start()
    {
       
        if (objetoAnimator != null)
        {
            objetoAnimator.SetTrigger(animacaoIdle);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player") && emIdle)
        {
            
            if (objetoAnimator != null)
            {
                objetoAnimator.SetTrigger(animacaoAtivacao);
            }

            emIdle = false;

            float delayDestruicao = 1.0f; 
            Destroy(gameObject, delayDestruicao);
        }
    }
}
