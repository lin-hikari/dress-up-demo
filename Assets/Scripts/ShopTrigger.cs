using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject shopCanvas;
    private string wrongTriggerMsg = "Shop trigger collision detected, but not from a Player";
    private string noCanvasReference = "Shop canvas reference not set!";

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag != "Player")
        {
            Debug.Log(wrongTriggerMsg);
            return;
        }
        if(shopCanvas == null)
        {
            Debug.Log(noCanvasReference);
            return;
        }

        shopCanvas.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Debug.Log(wrongTriggerMsg);
            return;
        }
        if (shopCanvas == null)
        {
            Debug.Log(noCanvasReference);
            return;
        }

        shopCanvas.SetActive(false);
    }
}
