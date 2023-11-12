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
    public Animator animator;
    private bool isDashing = false;
    public float dashSpeed = 100f;
    public float dashDuration = 0.5f;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        
        float moveX = Input.GetAxis("Horizontal");

        
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
        if (Input.GetKeyDown(KeyCode.P) && !isDashing){
            StartCoroutine(Dash());
            animator.SetBool("dash", true);
        } else {
            animator.SetBool("dash", false);
        }

    }

    
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == groundTag){
            nochao = true;
            animator.SetBool("pular", false);  
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

    IEnumerator Dash(){
        isDashing = true;

        float originalSpeed = moveSpeed; 

        moveSpeed = dashSpeed; 

        yield return new WaitForSeconds(dashDuration); 

        moveSpeed = originalSpeed; 

        isDashing = false;
    }
}
