using UnityEngine;
using TMPro;

/// <summary>
/// La clase TimeUI actualiza el texto del tiempo en un componente de TextMeshPro
/// 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    /// <summary>
    /// OnEnable es llamado cuando se activa un objeto en unity
    /// </summary>
    private void OnEnable()
    {
    TimeManager.OnMinuteChanged += UpdateTime;
    TimeManager.OnHourChanged += UpdateTime;
    }

    /// <summary>
    /// El metodo OnDisable es llamado cuando se desactiva un objeto
    /// </summary>
    private void OnDisable()
    {
        TimeManager.OnMinuteChanged -= UpdateTime;
        TimeManager.OnHourChanged -= UpdateTime;
    }

    /// <summary>
    /// Escribe el texto del tiempo en el contenedor para que lo vea el usuario
    /// </summary>
    private void UpdateTime()
    {
        timeText.text = $"{TimeManager.Hour.ToString("00")}:{TimeManager.Minute:00}";
    }
}
