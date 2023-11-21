using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
  
     private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float movePlayer = 10f;
    public float forcaPulo;
    public float gravityScale = 1.0f;
    public camera_fase1 cameraFollow;
    public Animator anima;

    private bool movimentoIniciado = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        cameraFollow = Camera.main.GetComponent<camera_fase1>();
        if (cameraFollow != null)
        {
            cameraFollow.SetTarget(transform);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !movimentoIniciado)
        {
            
            movimentoIniciado = true;

            
            gravityScale *= -1.0f;
            rb.gravityScale = gravityScale;

            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
        }

        if (movimentoIniciado)
        {
          
            transform.Translate(Vector2.right * (Time.deltaTime * movePlayer));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravityScale *= -1.0f;
            rb.gravityScale = gravityScale;

            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
        }

    } 
 
}
