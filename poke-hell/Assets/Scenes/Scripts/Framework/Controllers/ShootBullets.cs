using UnityEngine;
using System.Collections;


public class ShootBullets : MonoBehaviour
{   
    public BulletController bulletObject;
    public Transform offset;
    private float timer;

    private int numberOfStreams;
    private float fireInterval;   
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
        if(isTime(10, 3))
        {
            FireCorutine = StartCoroutine(FireLoop());
        } else if(isTime(10, 6))
        {
            StopCoroutine(FireCorutine);
        } else if(isTime(10, 7))
        {
            FireCorutine = StartCoroutine(FireLoop());
        } else if(isTime(10, 10))
        {
            StopCoroutine(FireCorutine);
        } else if(isTime(10, 11))
        {
            FireCorutine = StartCoroutine(FireLoop());
        } else if(isTime(10, 14))
        {
            StopCoroutine(FireCorutine);
        } else if(isTime(10, 15))
        {
            FireCorutine = StartCoroutine(FireLoop());
        } else if(isTime(10, 18))
        {
            StopCoroutine(FireCorutine);
        }
    }

    private IEnumerator FireLoop()
    {
        fireInterval = 0.1f;
        numberOfStreams = 9;
        while(true)
        {
            yield return StartCoroutine(Fire1(numberOfStreams));
            yield return new WaitForSeconds(fireInterval);
        }
    }

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

    private IEnumerator Fire2(int streams)
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

    private bool isTime(int hour, int minute)
    {
        return (TimeManager.Hour == hour && TimeManager.Minute == minute);
    }
}
