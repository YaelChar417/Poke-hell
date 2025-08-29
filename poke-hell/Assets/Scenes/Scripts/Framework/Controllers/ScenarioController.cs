using UnityEngine;

/// <summary>
/// La clase ScenarioController se encarga de mover los objetos con el escenario
/// hacia abajo y darse cuenta cuando haya tocado un punto en especifico para 
/// así generar nuevos escenarios 
///  
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class ScenarioController : MonoBehaviour
{   
    private float speed = Constants.SCENARIO_SPEED; // velocidad a la que baja
    public GameObject scenarioObject; // prefab del escenario
    public static ScenarioController singleton; // instancia de la clase unica

    /// <summary>
    /// Unity usa Awake para inicializar variables antes de que se ejecute la 
    ///  aplicación, se asigna como instancia de clase a ella misma.
    /// </summary>
    private void Awake()
    {
        singleton = this;
    }

    /// <summary>
    /// LateUpdate es llamado cada nuevo frame y siempre después de Update, 
    /// garantiza que el escenario cambie de posición y se mueva hacia abajo.
    /// </summary>
    void LateUpdate()
    {
        ScrollScenario();
    }


    /// <summary>
    /// Inicia con un ciclo for para cada hijo del objeto padre, en este caso
    /// el contenedor que es llamado ScenarioController en la escena y para cada
    /// objeto dentro de el, se recupera su posición actual, se le resta en su 
    /// posición en "y", la velocidad cada frame y finalmente se guarda esa 
    /// nueva posición, así moviendolo.
    /// </summary>
    void ScrollScenario()
    {
        foreach(Transform t in this.transform)
        {
            Vector2 position = t.transform.position;
            position.y -= speed * Time.deltaTime;
            t.transform.position = position;
        }
    }

    /// <summary>
    /// Obtiene el primer objeto dentro de ScenarioController para verificar si 
    /// ha sido activado, si no, lo activa, obtiene las coordenadas de donde fue 
    /// generado primero, para crear un nuevo objeto con las coordenadas de su 
    /// punto de inicio y destruye el viejo, así ahorrando recursos.
    /// </summary>
    public void SpawnScene()
    {   
        GameObject go = this.transform.GetChild(0).gameObject;
        Scenario s = go.GetComponent<Scenario>();
        
        if(!s.isTriggered)
        {  
            s.isTriggered = true;
            Transform t = s.spawnPoint;
            Instantiate(scenarioObject, t.position, Quaternion.identity, this.transform);
            Destroy(go);
        }
        
    }
}
