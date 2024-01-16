using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    public GameObject UICanvas;
    private string wrongTriggerMsg = "Trigger collision detected, but not from a Player";
    private string noCanvasReference = "UI reference not set!";

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Player")
        {
            Debug.Log(wrongTriggerMsg);
            return;
        }
        if(UICanvas == null)
        {
            Debug.Log(noCanvasReference);
            return;
        }

        UICanvas.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Debug.Log(wrongTriggerMsg);
            return;
        }
        if (UICanvas == null)
        {
            Debug.Log(noCanvasReference);
            return;
        }

        UICanvas.SetActive(false);
    }
}
