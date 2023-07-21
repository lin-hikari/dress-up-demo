using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int money;

    public GameObject[] yourItems, storeItems;

    private int currentPrice;

    private bool[] unlocks = new bool[6]; //0 = shirt 1, 1 = pants 1, 2 = shirt 2...

    private PlayerAnimator playAnim;

    void Start()
    {
        unlocks[0] = true;
        unlocks[1] = true;

        for(int i = 0; i < yourItems.Length; i++)
        {
            yourItems[i].SetActive(unlocks[i]);
            storeItems[i].SetActive(!unlocks[i]);
        }

        playAnim = GetComponent<PlayerAnimator>();
    }

    public void SetPrice(int price)
    {
        currentPrice = price;
    }

    public void SellItem(int itemID)
    {
        itemID--;

        unlocks[itemID] = false;
        money += currentPrice;

        yourItems[itemID].SetActive(false);
        storeItems[itemID].SetActive(true);

        //overly complicated way to deal with unequipping sold items because I made mistakes with the data design :(
        if((itemID % 2) == 0)
        {
            int unequipID = (itemID / 2) + 1;
            if (unequipID == playAnim.GetShirtID()) playAnim.ChangeShirt(0);
        }
        else
        {
            int unequipID = ((itemID - 1) / 2) + 1;
            if (unequipID == playAnim.GetPantsID()) playAnim.ChangePants(0);
        }
    }

    public void BuyItem(int itemID)
    {
        itemID--;

        if (currentPrice > money) return;

        unlocks[itemID] = true;
        money -= currentPrice;

        yourItems[itemID].SetActive(true);
        storeItems[itemID].SetActive(false);
    }
}
