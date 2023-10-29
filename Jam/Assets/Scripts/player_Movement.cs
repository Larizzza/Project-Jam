using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    string groundTag = "chao";
    private Rigidbody2D rb;
    private bool nochao = false;
    private bool viracara = true; 
    public GameObject pl;
    public GameObject bg;
    public Animator animator;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        pl.SetActive(true);
        bg.SetActive(true);
    }

    void Update(){
        
        float moveX = Input.GetAxis("Horizontal");

        // Adiciona a lógica para virar o personagem
        if (moveX > 0 && !viracara)
            Flip();
        else if (moveX < 0 && viracara)
            Flip();

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        
        if (moveX != 0){
            animator.SetBool("andar", true);
        } else {
            animator.SetBool("andar", false);
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && nochao){
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("pular", true);
        }         
        if (Input.GetKeyDown(KeyCode.P)){
            animator.SetTrigger("poder");
            animator.SetTrigger("tiro");
        } if (Input.GetKeyUp(KeyCode.P)){
        animator.SetBool("poder", false);
        animator.SetBool("tiro", false);
        }
    }

    
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == groundTag){
            nochao = true;
            animator.SetBool("pular", false);  // Desativa a animação de pulo quando o personagem toca o chão
        }
    }

    
    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == groundTag){
            nochao = false;
        }
    }

    void Flip(){
        viracara = !viracara;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
