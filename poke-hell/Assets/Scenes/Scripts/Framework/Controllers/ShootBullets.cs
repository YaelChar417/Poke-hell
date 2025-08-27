using UnityEngine;

public class ShootBullets : MonoBehaviour
{   
    public BulletController bulletObject;
    public Transform offset;
    private float timer;

    public int numberOfStreams = 5;
    private float radius = Constants.RADIUS;
    public float fireInterval = 0.5f;   
    public float angleOffset = -90.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > fireInterval)
        {
            timer = 0;
            Fire(numberOfStreams);
        }
    }

    void Fire(int streams)
    {
        float angleStep = 360.0f / streams;

        for(int i = 0; i <= streams - 1; i++)
        {
            float currentAngle = i * angleStep + angleOffset;
            float radians = currentAngle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;

            BulletController b = Instantiate(bulletObject, offset.position, Quaternion.identity, this.transform);
            b.direction = direction;
        }
    }
}
