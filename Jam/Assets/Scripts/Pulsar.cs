using UnityEngine;

public class Pulsar : MonoBehaviour
{
    private float escalaOriginal;
    private float velocidadePulso = 1f;
    private float magnitudePulso = 0.1f;

    void Start(){
        escalaOriginal = transform.localScale.x;
    }

    void Update(){
        Pulse();
    }

    void Pulse(){
        float escala = escalaOriginal + Mathf.Sin(Time.time * velocidadePulso) * magnitudePulso;
        transform.localScale = new Vector3(escala, escala, escala);
    }
}
