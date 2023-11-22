using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_Movement : MonoBehaviour
{
    [SerializeField] private float velocidadeMovimento = 5f;
    public float forcaPulo = 5f;
    [SerializeField] private int quantidadePulos = 2;
    private int pulosRestantes;
    string tagChao = "chao";
    string tagPlataforma = "plataforma";
    private Rigidbody2D rb;
    private bool noChao = false;
    private bool viradoParaDireita = true; 
    public Animator animador;
    public static int danoDash = 100;
    public static bool estaDandoDash = false;
    public int vida = 100;
    public GameObject painelGameOver;
    public int danoPedra = 20;
    public float duracaoDash = 3f; 
    [SerializeField] private float velocidadeDash = 50f;
    private float direcaoDash;
    [SerializeField] private Vector3 posicaoInicialDash;
    public camera_boss cameraFollow;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        pulosRestantes = quantidadePulos;

        cameraFollow = Camera.main.GetComponent<camera_boss>();
        if (cameraFollow != null){
            cameraFollow.SetTarget(transform);
        }
    }

    void Update(){
        
        float movimentoX = Input.GetAxis("Horizontal");
        
        if (movimentoX > 0 && !viradoParaDireita)
            Virar();
        else if (movimentoX < 0 && viradoParaDireita)
            Virar();

        if (estaDandoDash){
            if (Mathf.Abs(transform.position.x - posicaoInicialDash.x) < 2){
                rb.velocity = new Vector2(direcaoDash * velocidadeDash, rb.velocity.y);
            } else {
                estaDandoDash = false;
                animador.SetBool("dash", false);
            }
        } else {
            rb.velocity = new Vector2(movimentoX * velocidadeMovimento, rb.velocity.y);
        }
        
        if (movimentoX != 0){
            animador.SetBool("andar", true);
        } else {
            animador.SetBool("andar", false);
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && (noChao || pulosRestantes > 0)){
            if (!noChao) pulosRestantes--;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
            animador.SetBool("pular", true);
        }         
        if (Input.GetKeyDown(KeyCode.P) && !estaDandoDash){
            direcaoDash = Mathf.Sign(movimentoX);
            posicaoInicialDash = transform.position;
            StartCoroutine(Dash());
        }

        if (vida <= 0){
            Destroy(gameObject);
            painelGameOver.SetActive(true);
        }
    }

   IEnumerator Dash(){
    estaDandoDash = true;
    animador.SetBool("dash", true);
    yield return new WaitForSeconds(duracaoDash);
    estaDandoDash = false;
    animador.SetBool("dash", false);
    float movimentoX = Input.GetAxis("Horizontal");
    if (movimentoX != 0){
        animador.SetBool("andar", true);
    } else {
        animador.SetBool("andar", false);
    }
    }

    void OnCollisionEnter2D(Collision2D colisao){
        if (colisao.gameObject.tag == tagChao || colisao.gameObject.tag == tagPlataforma){
            noChao = true;
            pulosRestantes = quantidadePulos; 
            animador.SetBool("pular", false);  
        }
    }
    
    void OnCollisionExit2D(Collision2D colisao){
        if (colisao.gameObject.tag == tagChao || colisao.gameObject.tag == tagPlataforma){
            noChao = false;
        }
    }
    

    void OnTriggerEnter2D(Collider2D colisao){
        if (colisao.gameObject.CompareTag("Pedra")){
            vida -= danoPedra;
        } else if (estaDandoDash && colisao.gameObject.CompareTag("Boss")){
            boss_base boss = colisao.gameObject.GetComponent<boss_base>();
            boss.ReceberDano(100);
            estaDandoDash = false;
        }
    }

     void OnTriggerStay2D(Collider2D other){
        if (estaDandoDash && other.gameObject.CompareTag("Boss")){
            boss_base boss = other.gameObject.GetComponent<boss_base>();
            boss.ReceberDano(danoDash);
            estaDandoDash = false;
        }
    }

    void Virar(){
        viradoParaDireita = !viradoParaDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
