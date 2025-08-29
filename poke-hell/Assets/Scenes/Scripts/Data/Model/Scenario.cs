using UnityEngine;

/// <summary>
/// La clase Scenario, asigna dos variables a un objeto de unity, la primera es
/// spawnPoint, que habla de la posicion donde se quiere colocar un objeto y la
/// otra es isTriggered que nos será útil en su controller para quitar y crear
/// un nuevo escenario.
///  
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class Scenario : MonoBehaviour
{
    public Transform spawnPoint; // Coordenadas donde aparecerá el escenario
    public bool isTriggered; // Bandera para saber si se debe cambiar
}
