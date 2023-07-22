using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
