using UnityEngine;

public class ShootBullets : MonoBehaviour
{   
    public BulletController bulletObject;
    public Transform offset;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.1)
        {
            timer = 0;
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletObject, offset.position, Quaternion.identity, this.transform);
    }
}
