using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class game_Status : MonoBehaviour
{
    public player_Movement player;
    public Image[] hearts;

    void Update()
    {
        int fullHearts = Mathf.CeilToInt(player.vida / 20f);
        for (int i = 0; i < hearts.Length; i++){
            if (i < fullHearts){
                hearts[i].gameObject.SetActive(true);
            } else {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

}
