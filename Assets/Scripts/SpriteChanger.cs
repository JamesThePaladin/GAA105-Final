using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{

    // Declare our variables
    private SpriteRenderer sr; // variable for our renderer
    public Color spriteColor; // variable for our Color
    // Use this for initialization
    void Start()
    {
        float randR = Random.Range(0f, 1f);
        float randG = Random.Range(0f, 1f);
        float randB = Random.Range(0f, 1f);
        // Load the SpriteRenderer component from the same object this component is on.
        sr = gameObject.GetComponent<SpriteRenderer>();
        // Change the color from our color picker so that the alpha is 1
        spriteColor.r = randR;
        spriteColor.g = randG;
        spriteColor.b = randB;
        spriteColor.a = 1.0f;
        // As long as theRenderer has been set
        if (sr != null)
        {
            // Change the "color" value of the SpriteRenderer component to our new color
            sr.color = spriteColor;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}