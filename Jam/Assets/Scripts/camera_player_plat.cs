using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_player_plat : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("plataforma")){
        camera_boss.esta_na_plat = true;
    }
}

void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("plataforma")){
        camera_boss.esta_na_plat = false;
    }
}

}
