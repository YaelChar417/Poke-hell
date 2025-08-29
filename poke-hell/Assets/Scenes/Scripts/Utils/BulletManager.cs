using UnityEngine;
using System;

/// <summary>
/// La clase TimeManager es la encargada de contar el numero de balas que hay 
/// generadas en pantalla, aumentando en 1 por cada bala y cuando desaparece 
/// resta 1 del contador
/// 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public static class BulletManager
{
    public static int bulletNum {get; private set;} = 0;
    public static Action<int> onCountChanged;

    /// <summary>
    /// El metodo add incrementa el numero de balas en 1 y llama al evento 
    /// onCountChanged con el numero de balas
    /// </summary>
    public static void Add()
    {
        bulletNum++;
        onCountChanged?.Invoke(bulletNum);
    }
    
    /// <summary>
    /// El metodo Substract decrementa el numero de balas en 1 y llama al evento 
    /// onCountChanged con el numero de balas nuevo
    /// </summary>
    public static void Substract()
    {
        bulletNum = Mathf.Max(0, bulletNum - 1);
        onCountChanged?.Invoke(bulletNum);
    }
}
