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
        if(TimeManager.Hour == 10 && TimeManager.Minute == 2)
        {
            StartCoroutine(MoveEnemy());
        }
        
    }

    private IEnumerator MoveEnemy()
    {
        transform.position = new Vector3(-27.5f,3, -10);
        Vector3 targetPos = new Vector3(-15.5f,3, -10);

        Vector3 currentPos = transform.position;

        float timeElapsed = 0;
        float timeToMove = 3;

        while(timeElapsed < timeToMove){
            transform.position = Vector3.Lerp(currentPos,targetPos,timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

    }
}
