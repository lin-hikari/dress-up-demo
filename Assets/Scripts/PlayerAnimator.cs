using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

public class PlayerAnimator : MonoBehaviour
{
    public GameObject shirt, pants;
    public Sprite[] shirtStand, shirtMove, pantsStand, pantsMove;

    private int currentShirtID = 1;
    private int currentPantsID = 1;

    private SpriteRenderer shirtStandRend, shirtMoveRend, pantsStandRend, pantsMoveRend;

    void Start()
    {
        shirtStandRend = shirt.GetComponentsInChildren<SpriteRenderer>()[0];
        shirtMoveRend = shirt.GetComponentsInChildren<SpriteRenderer>()[1];
        pantsStandRend = pants.GetComponentsInChildren<SpriteRenderer>()[0];
        pantsMoveRend = pants.GetComponentsInChildren<SpriteRenderer>()[1];
    }

    public void ChangeShirt(int shirtID)
    {
        currentShirtID = shirtID;

        switch (shirtID)
        {
            case (0):
                shirtStandRend.sprite = null;
                shirtMoveRend.sprite = null;
                break;
            case (1):
                shirtStandRend.sprite = shirtStand[0];
                shirtMoveRend.sprite = shirtMove[0];
                break;
            case (2):
                shirtStandRend.sprite = shirtStand[1];
                shirtMoveRend.sprite = shirtMove[1];
                break;
            case (3):
                shirtStandRend.sprite = shirtStand[2];
                shirtMoveRend.sprite = shirtMove[2];
                break;
        }
    }

    public void ChangePants(int pantsID)
    {
        currentPantsID = pantsID;

        switch (pantsID)
        {
            case (0):
                pantsStandRend.sprite = null;
                pantsMoveRend.sprite = null;
                break;
            case (1):
                pantsStandRend.sprite = pantsStand[0];
                pantsMoveRend.sprite = pantsMove[0];
                break;
            case (2):
                pantsStandRend.sprite = pantsStand[1];
                pantsMoveRend.sprite = pantsMove[1];
                break;
            case (3):
                pantsStandRend.sprite = pantsStand[2];
                pantsMoveRend.sprite = pantsMove[2];
                break;
        }
    }

    public int GetShirtID()
    {
        return currentShirtID;
    }

    public int GetPantsID()
    {
        return currentPantsID;
    }
}
