using UnityEngine;
using System;

/// <summary>
/// La clase TimeManager simula a un reloj interno dentro del juego, sumando los
/// minutos y sumando horas cuando es conveniente
/// 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Minute{get; private set;}
    public static int Hour{get;private set;}

    private float minuteToRealTime = 1.0f;
    private float timer;

    /// <summary>
    /// El metodo Start es llamado unicamente una vez, inicializa los valores de 
    /// minutos y horas, ademas de reiniciar el valor del timer
    /// </summary>
    void Start()
    {
        Minute = 0;
        Hour = 10;
        timer = minuteToRealTime;
    }

    /// <summary>
    /// El metodo Update es llamado cada nuevo frame, resta el tiempo entre cada 
    /// frame al timer y cuando llegue a 0, significando que ha pasado un 
    /// segundo, suma un minuto, y si ya son 60 minutos entonces suma una hora
    /// activando eventos para actualizar el TMPro, cuando esto acaba, regresa 
    /// el timer a lo que nosotros queramos que sea un minuto.
    /// </summary>
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Minute++;

            OnMinuteChanged?.Invoke();

            if(Minute >= 60)
            {
                Hour++;
                OnHourChanged?.Invoke();
                Minute = 0;
            }

            timer = minuteToRealTime;
        }
    }
}
