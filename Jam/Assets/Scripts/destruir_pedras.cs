using UnityEngine;

public class destruir_pedras : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D colisao){
        if (colisao.gameObject.CompareTag("chao") || colisao.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
