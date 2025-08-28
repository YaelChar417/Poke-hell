using UnityEngine;
using System.Collections;


public class ShootBullets : MonoBehaviour
{   
    public BulletController bulletObject;
    public Transform offset;
    private float timer;

    public int numberOfStreams = 5;
    public float fireInterval = 0.5f;   
    public float angleOffset = -90.0f;
    private Coroutine FireCorutine;

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
            FireCorutine = StartCoroutine(FireLoop());
        }

        if(TimeManager.Hour == 10 && TimeManager.Minute == 15)
        {
            StopCoroutine(FireCorutine);
        }
    }

    private IEnumerator FireLoop()
    {
        while(true)
        {
            yield return StartCoroutine(Fire1(numberOfStreams));
            yield return new WaitForSeconds(fireInterval);
        }
    }

    private IEnumerator Fire1(int streams)
    {
        float angleStep = 360.0f / streams;

        for(int i = 0; i <= streams - 1; i++)
        {
            float currentAngle = i * angleStep + angleOffset;
            float radians = currentAngle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;

            BulletController b = Instantiate(bulletObject, offset.position, Quaternion.identity, this.transform);
            b.direction = direction;
            yield return null;            
        }
    }
}
