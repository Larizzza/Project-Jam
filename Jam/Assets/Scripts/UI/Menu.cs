using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
       public string cenaDestino;

    // Método chamado quando o botão é pressionado
    public void TrocarDeCena()
    {
        // Carrega a cena com o nome especificado
        SceneManager.LoadScene(cenaDestino);
    }
      
}

