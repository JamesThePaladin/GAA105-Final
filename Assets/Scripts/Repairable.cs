using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repairable : MonoBehaviour
{
    public GameObject fixedBot;
    float tarnish = 100;
    float repairRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Repair() 
    {
       tarnish = tarnish - repairRate * Time.deltaTime;
    }

    public void Repaired() 
    {
        if (tarnish < 1) 
        {
            Instantiate(fixedBot, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
