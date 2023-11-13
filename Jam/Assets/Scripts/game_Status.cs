using UnityEngine;
using UnityEngine.UI;

public class game_Status : MonoBehaviour
{
    public player_Movement player; 
    public boss_base boss; 

    public Text vida_player_text; 
    public Text vida_boss_text; 

    // Atualiza a cada frame
    void Update()
    {
        // Atualiza o texto na UI para corresponder à vida atual do jogador e do chefe
        vida_player_text.text = "Vida: " + player.vida;
        vida_boss_text.text = "Vida: " + boss.vida;
    }
}
