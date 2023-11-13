using UnityEngine;
using UnityEngine.UI;

public class vida_ui : MonoBehaviour
{
    public Transform jogador; 
    public Vector3 offset = new Vector3(1, 2, 0);

    void Update(){       
        transform.position = jogador.position + offset;
    }
}
