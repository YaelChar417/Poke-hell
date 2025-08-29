using UnityEngine;

/// <summary>
/// La clase AudioManager se encarga de manejar tanto la musica de fondo como 
/// los efectos de sonido
/// 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource; // objeto encargado de la musica de fondo
    public AudioSource SFXSource; // objeto encargado de los efectos de sonido

    public AudioClip background; // audio de la musica del fondo
    public AudioClip fireEffect; // audio del efecto de sonido para disparar

    /// <summary>
    /// El metodo Start es llamado unicamente una vez, reproduce la musica de 
    /// fondo al iniciar el juego
    /// </summary>
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    // <summary>
    /// El metodo PlaySound recibe un audio con un efecto de sonido y lo 
    /// reproduce unicamente una vez
    /// </summary>
    public void PlaySound(AudioClip sound)
    {
        SFXSource.PlayOneShot(sound);
    }
}
