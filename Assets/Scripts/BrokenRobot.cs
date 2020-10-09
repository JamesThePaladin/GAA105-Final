using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenRobot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.brokenRobots.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        GameManager.instance.brokenRobots.Remove(gameObject);
    }
}
