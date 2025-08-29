using UnityEngine;
using System.Collections;

/// <summary>
/// La clase EnemyController se encarga de realizar los movimiento del enemigo,
/// por tiempo, en esta se definen metodos para moverlo linealmente y tambien
/// rotandolo
/// 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class EnemyController : MonoBehaviour
{

    /// <summary>
    /// OnEnable es llamado cuando se activa un objeto en unity
    /// </summary>
    public void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    /// <summary>
    /// El metodo OnDisable es llamado cuando se desactiva un objeto
    /// </summary>
    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

    /// <summary>
    /// El metodo TimeCheck se definen las corrutinas del movimiento del enemigo
    /// y cambian entre si dependiendo del tiempo
    /// </summary>
    private void TimeCheck()
    {
        if(isTime(10, 1))
        {
            StartCoroutine(MoveEnemy(6));
        }
        else if(isTime(10, 6))
        {
            StartCoroutine(MoveEnemy(1));
        } 
        else if(isTime(10, 10))
        {
            StartCoroutine(MoveEnemy(2));
        } 
        else if(isTime(10, 14))
        {
            StartCoroutine(MoveEnemy(3));
        } 
        else if(isTime(10, 18))
        {
            StartCoroutine(MoveEnemy(5));
        }
        else if(isTime(10, 20))
        {
            StartCoroutine(RotateEnemy());
        }
        else if(isTime(10, 58))
        {
            StartCoroutine(MoveEnemy(7));
        }
    }

    /// <summary>
    /// El metodo RotateEnemy, mueve al enemigo en forma rotacional, pero 
    /// manteniendo su sprite fijo, es decir que solo rota alrededor de un punto
    /// pero no de si mismo, se declara un contador de tiempo, el tiempo deseado
    /// que rote, su velocidad y el punto de un centro, además que con Quaternion
    /// se mantiene su propia rotacion.
    /// Despues usando el metodo de Unity RotateAround se hace que gire alrededor
    /// de un punto
    /// </summary>
    private IEnumerator RotateEnemy()
    {
        float timeElapsed = 0f;
        float timeToMove = 14.4f;
        float rotationSpeed = 200.0f;
        Vector3 center = new Vector3(-20.0f, 0f, -10);
        Quaternion originalRotation = transform.rotation;

        while(timeElapsed < timeToMove)
        {
            transform.RotateAround(center, Vector3.forward, rotationSpeed * Time.deltaTime);
            transform.rotation = originalRotation;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    /// <summary>
    /// El metodo MoveEnemy mueve de forma lineal al enemigo, como se usa mucho
    /// el movimiento lineal se utilizo un switch/case para determinar las
    /// posiciones de inicio y fin y posteriormente la funcion se encarga de 
    /// trasladar al enemigo hasta ese punto, con ayuda del tiempo que ha pasado
    /// y el tiempo que se desea que tarde en ese movimiento
    /// 
    /// @param order -> int: hace referencia al tipo de movimiento que se 
    ///     requiere, como ejemplo se puede mover de afuera del escenario hacia 
    ///     la izquierda, de izquierda al centro, del centro a la derecha, etc
    /// </summary>
    private IEnumerator MoveEnemy(int order)
    {
        float timeElapsed = 0f;
        float timeToMove = 1.0f;
        Vector3 targetPos;
        Vector3 currentPos;

        switch(order)
        {
            case 1: // del centro a la izquierda
                transform.position = new Vector3(-20.0f, 4.0f, -10);
                targetPos = new Vector3(-25.5f, 3.0f, -10);

                currentPos = transform.position;
                break;
            case 2: // de la izquierda al centro
                transform.position = new Vector3(-25.5f, 3.0f, -10);
                targetPos = new Vector3(-20.0f, 4.0f, -10);

                currentPos = transform.position;
                break;
            case 3: // Del centro a la derecha
                transform.position = new Vector3(-20.0f, 4.0f, -10);
                targetPos = new Vector3(-15.5f, 3.0f, -10);

                currentPos = transform.position;
                break;
            case 4: // derecha al centro
                transform.position = new Vector3(-15.5f, 3.0f, -10);
                targetPos = new Vector3(-20.0f, 4.0f, -10);

                currentPos = transform.position;
                break;
            case 5: // derecha al centro en x, y
                transform.position = new Vector3(-15.5f, 3.0f, -10);
                targetPos = new Vector3(-20.0f, 2.0f, -10);

                currentPos = transform.position;
                break;
            case 6: // entrada de afuera al centro
                transform.position = new Vector3(-9.5f, 0f, -10);
                targetPos = new Vector3(-20.0f, 4.0f, -10);

                currentPos = transform.position;
                break;
            case 7: // del centro en x, y hacia afuera del escenario
                targetPos = new Vector3(-30.5f, -4.0f, -10);
                currentPos = transform.position;
                break;
            default: 
                yield break;
        }

        while(timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos,targetPos,timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    /// <summary>
    /// El metodo isTime retorna si la hora del contador del tiempo es igual
    /// a la hora actual y si los minutos del contador son iguales a los minutos 
    /// actuales, para así reducir lineas de codigo y mejorar la legibilidad del
    /// codigo
    /// </summary>
    private bool isTime(int hour, int minute)
    {
        return (TimeManager.Hour == hour && TimeManager.Minute == minute);
    }
}
