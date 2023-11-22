using UnityEngine;

public class sons : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuSound;
    public AudioClip fase1Sound;
    public AudioClip bossFaseSound;
    public AudioClip creditosSound;
    public AudioClip clickHUDSound;
    public AudioClip raioFase1Sound;
    public AudioClip andandoFase2Sound;
    public AudioClip dashSound;
    public AudioClip vilaoGritoSound;
    public AudioClip murroSound;

    void Start()
    {
        // Aqui estamos chamando PlaySound no início do jogo
        PlaySound(menuSound);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
