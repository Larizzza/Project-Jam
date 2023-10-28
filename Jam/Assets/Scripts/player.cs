using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
  
    private Rigidbody2D rb;
    public float movePlayer = 10f;
    public float forcaPulo;
    public float gravityScale = 1.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * movePlayer));

        if (Input.GetKeyDown (KeyCode.A))
        {
             rb.AddForce(Vector3.up * forcaPulo, ForceMode2D.Impulse);
        }

         if (Input.GetKeyDown(KeyCode.Space))
        {
            
            gravityScale *= -1.0f;
            rb.gravityScale = gravityScale;
        }
    
    }

   
}
