using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public int money;

    public GameObject[] yourItems, storeItems;

    public TextMeshProUGUI moneyText;

    private int currentPrice;

    private bool[] unlocks = new bool[6]; //even number is shirt, odd number is pants

    private PlayerAnimator playAnim;

    void Start()
    {
        //you start with the basic shirt and pants unlocked
        unlocks[0] = true;
        unlocks[1] = true;

        //initializing shop UI
        for(int i = 0; i < yourItems.Length; i++)
        {
            yourItems[i].SetActive(unlocks[i]);
            storeItems[i].SetActive(!unlocks[i]);
        }

        moneyText.text = "Money: " + money.ToString();

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

        moneyText.text = "Money: " + money.ToString();

        yourItems[itemID].SetActive(false);
        storeItems[itemID].SetActive(true);

        //figuring out whether the item is a shirt or pants, and if it is equipped so it is removed in that case
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

        moneyText.text = "Money: " + money.ToString();

        yourItems[itemID].SetActive(true);
        storeItems[itemID].SetActive(false);
    }
}
