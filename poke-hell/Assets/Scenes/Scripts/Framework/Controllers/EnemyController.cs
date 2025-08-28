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
            StartCoroutine(MoveEnemy(1));
        } else if(isTime(10, 10))
        {
            StartCoroutine(MoveEnemy(2));
        }

        
    }

    private IEnumerator MoveEnemy(int order)
    {
        float timeElapsed = 0;
        float timeToMove = 3;
        Vector3 targetPos;
        Vector3 currentPos;
        
        switch(order)
        {
            case 1:
                transform.position = new Vector3(-27.5f,3, -10);
                targetPos = new Vector3(-15.5f,3, -10);

                currentPos = transform.position;

                while(timeElapsed < timeToMove){
                    transform.position = Vector3.Lerp(currentPos,targetPos,timeElapsed/timeToMove);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }
                break;
            case 2:
                transform.position = new Vector3(-15.5f,3, -10);
                targetPos = new Vector3(-27.5f,3, -10);

                currentPos = transform.position;

                while(timeElapsed < timeToMove){
                    transform.position = Vector3.Lerp(currentPos,targetPos,timeElapsed/timeToMove);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }
                break;
            default: 
                yield return null;
                break;
        }
    }

    private bool isTime(int hour, int minute)
    {
        return (TimeManager.Hour == hour && TimeManager.Minute == minute);
    }
}
