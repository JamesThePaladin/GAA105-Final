using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver() 
    {
        yield return new WaitForSeconds(10f);
        Application.Quit();
    }
}
