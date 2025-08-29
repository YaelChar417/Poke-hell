using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }

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
            case 7:
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

    private bool isTime(int hour, int minute)
    {
        return (TimeManager.Hour == hour && TimeManager.Minute == minute);
    }
}
