using UnityEngine;

public class sons : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioClip menuSound;
    public AudioClip fase1Sound;
    public AudioClip bossFaseSound;
    public AudioClip creditosSound;

    void Start(){
        PlayMusic(menuSound);
    }

    public void PlayMusic(AudioClip clip){
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }
}
