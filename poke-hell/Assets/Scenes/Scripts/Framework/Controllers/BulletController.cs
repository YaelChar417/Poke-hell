using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = Constants.BULLET_SPEED;
    private float timeCount;
    private float bulletLife = Constants.BULLET_LIFE;
    public Vector2 direction = Vector2.down;

    void OnEnable()
    {
        BulletManager.Add();
    }

    void OnDisable()
    {
        BulletManager.Substract();
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
        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
}
