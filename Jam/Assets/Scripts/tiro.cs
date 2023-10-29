using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
{
    public GameObject explosaoPrefab;
    public float velocidadeDaBala = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            GameObject explosao = Instantiate(explosaoPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = explosao.GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * velocidadeDaBala;
            Destroy(explosao, 4f);
        }
    }
}
