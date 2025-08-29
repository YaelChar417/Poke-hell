using UnityEngine;

/// <summary>
/// La clase ColliderController que asigna a un objeto con la propiedad de 
/// RigidBody para verificar si hubo una colisión y así poder cambiar el 
/// escenario.
///  
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class ColliderController : MonoBehaviour
{
    public Rigidbody2D rigidbody2D; // objeto con propiedad RigidBody

    /// <summary>
    /// El metodo OnTriggerEnter2D se activa cuando un ojeto colisiona con otro 
    /// que tenga la propiedad Collider2D, verifica si ese objeto tiene la 
    /// etiqueta ScenarioTrigger para llamar al metodo SpawnScene de la clase 
    /// ScenarioController
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScenarioTrigger")
        {
            ScenarioController.singleton.SpawnScene();
        }
    }
}
