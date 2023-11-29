using UnityEngine;

public class Efeitos : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    public AudioClip clickHUDSound;
    public AudioClip raioFase1Sound;
    public AudioClip andandoFase2Sound;
    public AudioClip vilaoGritoSound;
    public AudioClip murroSound;
    public AudioClip[] dashSounds;

    public void PlaySound(AudioClip clip){
        sfxAudioSource.clip = clip;
        sfxAudioSource.Play();
    }

    public void StopSound(){
        sfxAudioSource.Stop();
    }

    public void PlayRandomDashSound(){
        int index = Random.Range(0, dashSounds.Length);
        sfxAudioSource.clip = dashSounds[index];
        sfxAudioSource.Play();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            PlaySound(clickHUDSound);
        }
    }
}
