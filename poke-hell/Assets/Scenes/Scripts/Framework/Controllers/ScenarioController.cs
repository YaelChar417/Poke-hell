using UnityEngine;

public class ScenarioController : MonoBehaviour
{   
    private float speed = Constants.SCENARIO_SPEED;
    public GameObject scenarioObject;
    public static ScenarioController singleton;

    private void Awake()
    {
        singleton = this;
    }

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

    public void SpawnScene()
    {   
        GameObject go = this.transform.GetChild(0).gameObject;
        Scenario s = go.GetComponent<Scenario>();
        
        if(!s.isTriggered)
        {  
            s.isTriggered = true;
            Transform t = s.spawnPoint;
            Instantiate(scenarioObject, t.position, Quaternion.identity, this.transform);
            Destroy(go);
        }
        
    }
}
