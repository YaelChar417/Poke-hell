using UnityEngine;
using TMPro;

/// <summary>
/// La clase CounterUI actualiza el texto del numero de balas en un componente 
/// de TextMeshPro
/// 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class CounterUI : MonoBehaviour
{
    public TextMeshProUGUI bulletCounter;

    /// <summary>
    /// OnEnable es llamado cuando se activa un objeto en unity, actualiza la 
    /// cantidad del contador con el numero de balas actuales.
    /// </summary>
    void OnEnable()
    {
        BulletManager.onCountChanged += UpdateCounter;
        UpdateCounter(BulletManager.bulletNum);
    }

    /// <summary>
    /// El metodo OnDisable es llamado cuando se desactiva un objeto, cuando se 
    /// desactiva vuelve a la cantidad por defecto, es decir 0
    /// </summary>
    void OnDisable()
    {
        BulletManager.onCountChanged -= UpdateCounter;
    }

    /// <summary>
    /// El metodo UpdateCounter recibe un numero de balas que es el que escribe 
    /// en el objeto de tipo TMPro, para que lo vea el usuario
    /// </summary>
    void UpdateCounter(int num)
    {
        bulletCounter.text = $"{num}";
    }
}
