using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_ataque : MonoBehaviour
{
    public GameObject[] prefabPedras; 
    public Transform[] pontosSpawn;
    public Transform camerinha; 
    private float temporizadorDano = 0f;
    private float intervaloDano = 8f;
    [SerializeField] private int quantidadePedras = 2;
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    void Update(){
        temporizadorDano += Time.deltaTime;
        if (temporizadorDano >= intervaloDano){
            Murro();
            temporizadorDano = 0f;
        }
    }

    void Murro(){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D colisao){
        if (colisao.gameObject.CompareTag("Teto")){
            SoltarPedras();             
        }
    }

    void SoltarPedras(){
        for (int i = 0; i < pontosSpawn.Length; i++){
            for (int j = 0; j < quantidadePedras; j++){
                float deslocamentoX = Random.Range(-3f, 3f);
                float deslocamentoY = Random.Range(-3f, 3f);
                Vector3 posicaoSpawn = pontosSpawn[i].position + new Vector3(deslocamentoX, deslocamentoY, 0);
                Instantiate(prefabPedras[i], posicaoSpawn, pontosSpawn[i].rotation);
                StartCoroutine(ShakeCamera(0.15f, 0.4f));
            }
        }
    }

    IEnumerator ShakeCamera(float duration, float magnitude) {
        Vector3 originalPosition = camerinha.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration) {
            float x = Random.Range(-2f, 0.5f) * magnitude;
            float y = Random.Range(-1f, 0.5f) * magnitude;

            camerinha.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        camerinha.localPosition = originalPosition;
    }
}
