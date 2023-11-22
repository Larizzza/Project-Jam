using UnityEngine;
using UnityEngine.UI;

public class game_Status : MonoBehaviour
{
    public player_Movement player; 
    public boss_base boss; 

    public Text vida_player_text; 
    public Text vida_boss_text; 

    void Update(){
        vida_player_text.text = "Vida: " + player.vida;
        vida_boss_text.text = "Vida: " + boss.vida;
    }
}
