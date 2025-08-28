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
        if(isTime(10, 2))
        {
            StartCoroutine(MoveEnemy(4));
        } else if(isTime(10, 8))
        {
            StartCoroutine(MoveEnemy(1));
        } else if(isTime(10, 14))
        {
            StartCoroutine(MoveEnemy(2));
        } else if(isTime(10, 20))
        {
            StartCoroutine(MoveEnemy(3));
        }

        
    }

    private IEnumerator MoveEnemy(int order)
    {
        float timeElapsed = 0;
        float timeToMove = 1;
        Vector3 targetPos;
        Vector3 currentPos;

        switch(order)
        {
            case 1: // del centro a la izquierda
                transform.position = new Vector3(-20.0f, 4.0f, -10);
                targetPos = new Vector3(-27.5f, 3.0f, -10);

                currentPos = transform.position;
                break;
            case 2: // de la izquierda al centro
                transform.position = new Vector3(-27.5f, 3.0f, -10);
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
