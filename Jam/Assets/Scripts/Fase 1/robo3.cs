using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class robo3 : MonoBehaviour
{
    
    public string nomeDaCena; 
    public Transform pontoInicial;
    public Transform pontoFinal;
    public float velocidade = 5f;
    private Transform destino;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        destino = pontoFinal;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Move o NPC em direção ao destino
        transform.position = Vector2.MoveTowards(transform.position, destino.position, velocidade * Time.deltaTime);

        // Verifica a direção do movimento e flipa o sprite se necessário
        if (transform.position.x < destino.position.x)
        {
            spriteRenderer.flipX = false; // Não flipa o sprite se estiver indo para a direita
        }
        else
        {
            spriteRenderer.flipX = true; // Flipa o sprite se estiver indo para a esquerda
        }

        // Se o NPC atingir o ponto final, troca o destino para o ponto inicial
        if (Vector2.Distance(transform.position, pontoFinal.position) < 0.1f)
        {
            destino = pontoInicial;
        }

        // Se o NPC atingir o ponto inicial, troca o destino para o ponto final
        if (Vector2.Distance(transform.position, pontoInicial.position) < 0.1f)
        {
            destino = pontoFinal;
        }

        // Adicione aqui lógica adicional, como animações, detecção de jogador, etc.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            SceneManager.LoadScene(nomeDaCena);
        }
    }

}
