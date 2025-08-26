using UnityEngine;

public class ScenarioController : MonoBehaviour
{   
    public float speed = Constants.SCENARIO_SPEED;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ScrollScenario();
    }

    void ScrollScenario()
    {
        foreach(Transform t in this.transform)
        {
            Vector2 position = t.transform.position;
            position.y -= speed * Time.deltaTime;
            t.transform.position = position;
        }
    }
}
