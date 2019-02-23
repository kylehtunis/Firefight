using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{

    public static int maxNumberOfFires = 5000;

    public static int numberOfFires = 0;

    public bool lastLevel;

    public static int level = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(level);
        }
        if (Input.GetKeyUp(KeyCode.Backspace) && level <= 1)  
        {
            level--;
            SceneManager.LoadScene(level);
        }
        if (numberOfFires == 0) 
        {
            if (lastLevel)
            {
                level = 1;
                SceneManager.LoadScene(level);
            }
            else
            {
                level++;
                SceneManager.LoadScene(level);
            }
        }
    }
}
