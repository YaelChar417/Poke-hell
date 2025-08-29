using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;

    public AudioClip background;
    public AudioClip fireEffect;

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySound(AudioClip sound)
    {
        SFXSource.PlayOneShot(sound);
    }
}
