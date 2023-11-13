using UnityEngine;

public class bolinha : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D colisao){
        if (colisao.gameObject.CompareTag("Boss") || colisao.gameObject.CompareTag("Teto")){
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
