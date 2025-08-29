using UnityEngine;

/// <summary>
/// La clase BulletController controla el comportamiento de cada bala en el 
/// juego, desde la velocidad, direccion e incluso el tiempo en que esta activa 
/// en el escenario
/// 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class BulletController : MonoBehaviour
{
    private float speed = Constants.BULLET_SPEED;
    private float timeCount;
    private float bulletLife = Constants.BULLET_LIFE;
    public Vector2 direction = Vector2.down;

    /// <summary>
    /// OnEnable es llamado cuando se activa un objeto en unity, en este caso 
    /// llama al metodo de BulletManager par sumar una bala
    /// </summary>
    void OnEnable()
    {
        BulletManager.Add();
    }

    /// <summary>
    /// El metodo OnDisable es llamado cuando se desactiva un objeto, en este 
    /// caso llama al metodo de BulletManager para restar una bala
    /// </summary>
    void OnDisable()
    {
        BulletManager.Substract();
    }

    /// <summary>
    /// El metodo Update es llamado cada nuevo frame, verifica si el tiempo que
    /// ha estado una bala es mayor que el tiempo de vida, si lo es destruye el 
    /// objeto de bala, sino aumenta su tiempo a la cantidad de tiempo que paso 
    /// entre frames y mueve la bala hacia adelante
    /// </summary>
    void Update()
    {   
        if (timeCount > bulletLife)
        {
            Destroy(this.gameObject);
        }

        timeCount += Time.deltaTime;
        MoveForward();
    }

    /// <summary>
    /// El metodo MoveForward mueve a la bala en una direccion, en este caso por
    /// defecto es hacia abajo y lo hace con la velocidad y el numero de frames
    /// para que se mueva de igual forma en cada equipo
    /// </summary>
    void MoveForward()
    {
        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
}
