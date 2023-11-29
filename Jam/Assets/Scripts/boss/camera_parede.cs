using UnityEngine;

public class camera_parede : MonoBehaviour
{
    public Transform alvo;
    public Vector2 posMinCam;
    public float suavizacao = 0.5f; // Valor para controlar a velocidade de suavização
    private Vector3 velocidade = Vector3.zero;

    void FixedUpdate()
    {
        float posX = Mathf.Max(alvo.position.x, posMinCam.x);
        float posY = Mathf.Max(alvo.position.y, posMinCam.y);

        Vector3 posAlvo = new Vector3(posX, posY, transform.position.z);

        // Suaviza a mudança de posição da câmera ao longo do tempo
        transform.position = Vector3.SmoothDamp(transform.position, posAlvo, ref velocidade, suavizacao);
    }
}
