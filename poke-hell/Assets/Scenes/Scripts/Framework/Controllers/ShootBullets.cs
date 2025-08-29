using UnityEngine;
using System.Collections;

/// <summary>
/// La clase ShootBullets es la encarga de crear los 3 diferentes patrones 
/// utilizando tiempo para cambiar entre ellos
/// 
/// Standar coding documentation can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class ShootBullets : MonoBehaviour
{   
    public BulletController bulletObject; // prefab de las balas
    public Transform offset; // posicion de donde se quiere que aparezcan
    private float timer; // contador interno

    private int numberOfStreams; // numero de chorros de balas
    private float fireInterval; // intervalo entre bala y bala
    public float angleOffset = -90.0f; // angulo para que las balas salgan hacia abajo
    private Coroutine FireCorutine; // corrutina usada para almacenar otras
    AudioManager audioManager; // controlador de audio para los disparos

    /// <summary>
    /// Unity usa Awake para inicializar variables antes de que se ejecute la 
    ///  aplicación, obtiene al objeto del AudioManager usando su etiqueta
    /// </summary>
    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

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
    /// El metodo TimeCheck se definen las corrutinas de los disparos del 
    /// enemigo, se encarga de activar cuando dispara, cuando deja de disparar y
    /// que tipo de disparo usa, relacionado ampliamente con su movimiento, usa
    /// tiempo para determinar estas decisiones
    /// </summary>
    private void TimeCheck()
    {
        if(isTime(10, 3))
        {
            FireCorutine = StartCoroutine(FireLoop(1));
        } 
        else if(isTime(10, 6))
        {
            StopCoroutine(FireCorutine);
        } 
        else if(isTime(10, 7))
        {
            FireCorutine = StartCoroutine(FireLoop(1));
        } 
        else if(isTime(10, 10))
        {
            StopCoroutine(FireCorutine);
        } 
        else if(isTime(10, 11))
        {
            FireCorutine = StartCoroutine(FireLoop(1));
        } 
        else if(isTime(10, 14))
        {
            StopCoroutine(FireCorutine);
        } 
        else if(isTime(10, 15))
        {
            FireCorutine = StartCoroutine(FireLoop(1));
        } 
        else if(isTime(10, 18))
        {
            StopCoroutine(FireCorutine);
        } 
        else if(isTime(10, 20))
        {
            FireCorutine = StartCoroutine(FireLoop(2));
        } 
        else if(isTime(10, 35))
        {
            StopCoroutine(FireCorutine);
        }
        else if(isTime(10, 36))
        {
            FireCorutine = StartCoroutine(FireLoop(3));
        }
        else if(isTime(10, 56))
        {
            StopCoroutine(FireCorutine);
        }
    }

    /// <summary>
    /// El metodo FireLoop, es el encargado de seleccionar que corrutina o patron
    /// de ataque se estará usando, así como establecer el tiempo entre balas y 
    /// numero de chorros de balas, utilizando un switch para determinar que 
    /// patron usar
    /// 
    /// @param opcion -> int: hace referencia al tipo de patron de ataque.
    ///     1 -> patron de ataque lineal, con multiples chorros y lineal
    ///     2 -> patron de ataque circular con chorros separados por un angulo
    ///     3 -> patron de ataque lineal pero de barrido circular.
    /// </summary>
    private IEnumerator FireLoop(int opcion)
    {
        switch(opcion)
        {
            case 1: // ataque lineal y recto
                fireInterval = 0.1f;
                numberOfStreams = 9;
                while(true)
                {
                    audioManager.PlaySound(audioManager.fireEffect);
                    yield return StartCoroutine(Fire1(numberOfStreams));
                    yield return new WaitForSeconds(fireInterval);
                }
            case 2: // ataque ciruclar separado ente si por un angulo
                fireInterval = 0.5f;
                numberOfStreams = 10;
                while(true)
                {
                    audioManager.PlaySound(audioManager.fireEffect);
                    yield return StartCoroutine(Fire2(numberOfStreams));
                    yield return new WaitForSeconds(fireInterval);
                }
            case 3: // ataque lineal de barrido circular
                fireInterval = 0.2f;
                numberOfStreams = 3;
                while(true)
                {
                    yield return StartCoroutine(Fire3(numberOfStreams, fireInterval));
                }
            default:
                yield break;
        }
        
    }

    /// <summary>
    /// El metodo Fire1 hace un patron lineal y hacia abajo de chorros repetidos
    /// se declara su direccion por default, que es hacia abajo.
    /// 
    /// se crea un vector perpendicular a esta para posicionar las diferentes 
    ///     balas a partir de un offset.
    /// centra la posicion de las balas a partir del offset dado.
    /// se calcula una posicion para los fuegos desplazada hacia un lado segun 
    ///     la iteracion.
    /// se instancia una nueva bala con la posicion calculada y se asigna su 
    ///     direccion que es hacia abajo.
    /// </summary>
    private IEnumerator Fire1(int streams)
    {
        Vector2 direction = Vector2.down.normalized;
        Vector2 perpendicular = new Vector2(-direction.y, direction.x);

        float half = (streams - 1.0f) / 2.0f;

        for(int i  = 0; i < streams; i++)
        {
            Vector2 temp = (Vector2)offset.position + perpendicular * ((i - half) * 0.5f);
            Vector3 spawnPos = new Vector3(temp.x, temp.y, -10);
            BulletController b = Instantiate(bulletObject, spawnPos, Quaternion.identity, this.transform);
            b.direction = direction;
            yield return null;
        }
    }

    /// <summary>
    /// El metodo Fire2 hace un patron de balas circular separado por un angulo 
    /// que es calculado dependiendo del numero de chorros de balas que se 
    /// requiera.
    /// 
    /// Calcula la separacion del angulo dependiendo de los chorros de balas.
    /// Calcula el angulo que debe tener cada chorro de balas dependiendo de la 
    ///     iteracion y también se le suma un offset para que la primera tenga
    ///     una direccion hacia abajo, despues se pasa a radianes.
    /// Se crea un vector con la direccion en x, usando el coseno y en y usando 
    ///     el seno, se normaliza ese vector para no tener velocidades mayores 
    ///     si se va en diagonal.
    /// Se crea un objeto de bala con la posicion del offset y se le asigna su
    ///     direccion calculada previamente.
    /// </summary>
    private IEnumerator Fire2(int streams)
    {
        float angleStep = 360.0f / streams;

        for(int i = 0; i < streams; i++)
        {
            float currentAngle = i * angleStep + angleOffset;
            float radians = currentAngle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;

            BulletController b = Instantiate(bulletObject, offset.position, Quaternion.identity, this.transform);
            b.direction = direction;
            yield return null;            
        }
    }

    /// <summary>
    /// El metodo Fire3 crea una serie de chorros de balas que se van moviendo
    /// circularmente hasta completar dos vueltas completas empezando desde -90°
    /// y terminando en 270°
    /// 
    /// Se establecen variables que se usaran en el ciclo for para evitar que se
    ///     declaren de nuevo.
    /// Se define un tiempo de disparo, angulo inicial y el intervalo de grados
    ///     dependiendo del tiempo total de disparo
    /// Se define un contador global y se hace lo mismo que en Fire1, de crear 
    ///     un vector perpendicular para colocar las balas
    /// Mientra que el tiempo actual sea menor al tiempo entre balas, se establece
    ///     un angulo un angulo a partir del angulo inicial, el intervalo entre
    ///     angulos y el tiempo que ha pasado
    /// Se convierte ese angulo a radianes, se crea un vector que tenga las 
    ///     direcciones en x, y de ese angulo usando el coseno y seno 
    ///     respectivamente
    /// Se define el vector perpendicular a su nueva posicion para situar los 
    ///     disparos.
    /// Por cada chorro de balas se define su posicion centrando las balas a 
    ///     partir de la posicion de disparo deseada (offset) y se instancian 
    ///     balas, asignandoles la direccion calculada, posteriormente se espera
    ///     el intervalo entre disparos para repetir este proceso
    /// </summary>
    private IEnumerator Fire3(int streams, float fireInterval)
    {
        float angle, radians; 
        float timeToShoot = 10.0f;
        float startAngle = -90.0f; 
        float degreesPerSecond = 360.0f / timeToShoot;
        float timeElapsed = 0f;
        float half = (streams - 1.0f) / 2.0f;

        while(timeElapsed < timeToShoot)
        {
            angle = startAngle + degreesPerSecond * timeElapsed;
            radians = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;
            Vector2 perpendicular = new Vector2 (-direction.y, direction.x);
            audioManager.PlaySound(audioManager.fireEffect);
            
            for (int i = 0; i < streams; i++)
            {
                
                Vector2 temp = (Vector2)offset.position + perpendicular * ((i - half) * 0.5f);
                Vector3 spawnPos = new Vector3(temp.x, temp.y, -10);
                BulletController b = Instantiate(bulletObject, spawnPos, Quaternion.identity, this.transform);
                b.direction = direction;
            }

            yield return new WaitForSeconds(fireInterval);
            timeElapsed += fireInterval;
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
