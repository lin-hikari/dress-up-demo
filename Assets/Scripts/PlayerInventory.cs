using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int money;

    public GameObject[] yourItems, storeItems;

    private int currentPrice;

    private bool[] unlocks = new bool[6]; //0 = shirt 1, 1 = pants 1, 2 = shirt 2...

    void Start()
    {
        unlocks[0] = true;
        unlocks[1] = true;

        for(int i = 0; i < yourItems.Length; i++)
        {
            yourItems[i].SetActive(unlocks[i]);
            storeItems[i].SetActive(!unlocks[i]);
        }
    }

    public void SetPrice(int price)
    {
        currentPrice = price;
    }

    public void SellItem(int itemID)
    {
        unlocks[itemID - 1] = false;
        money += currentPrice;

        yourItems[itemID - 1].SetActive(false);
        storeItems[itemID - 1].SetActive(true);
    }

    public void BuyItem(int itemID)
    {
        if (currentPrice > money) return;

        unlocks[itemID - 1] = true;
        money -= currentPrice;

        yourItems[itemID - 1].SetActive(true);
        storeItems[itemID - 1].SetActive(false);
    }
}
