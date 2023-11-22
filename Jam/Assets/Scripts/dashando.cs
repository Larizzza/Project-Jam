using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashando : MonoBehaviour
{
        void OnTriggerEnter2D(Collider2D colisao){
        if (player_Movement.estaDandoDash && colisao.gameObject.CompareTag("Boss")){
            boss_base boss = colisao.gameObject.GetComponent<boss_base>();
            boss.ReceberDano(player_Movement.danoDash);
            player_Movement.estaDandoDash = false;
        }
    }
}
