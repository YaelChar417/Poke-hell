using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = Constants.BULLET_SPEED;
    private float timeCount;
    private float bulletLife = Constants.BULLET_LIFE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (timeCount > bulletLife)
        {
            Destroy(this.gameObject);
        }

        timeCount += Time.deltaTime;
        MoveForward();
    }

    void MoveForward()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
}
