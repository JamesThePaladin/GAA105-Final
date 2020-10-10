using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repairable : MonoBehaviour
{
    public GameObject fixedBot;
    public float health = 0;
    public float repairRate = 20;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Repaired();
    }

    public void Repair() 
    {
       health += repairRate * Time.deltaTime;
       healthText.text = "" + health;
    }

    public void Repaired() 
    {
        if (health >= 100) 
        {
            Instantiate(fixedBot, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
