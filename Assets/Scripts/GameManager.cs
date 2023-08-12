using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int gold;

    Item activeClothes;
    Item activeHair;
    Item activeHat;

    public int Gold { get => gold; set => gold = value; }

    [HideInInspector] public UnityEvent<int> onChangedGold;
    [HideInInspector] public UnityEvent<Item> onItemBought;

    private void Awake()
    {
        instance = this;
    }

    public void SetGold(int value)
    {
        gold += value;
        onChangedGold.Invoke(gold);
    }

    public void BuyItem(Item item)
    {
        if (!item.bought)
        {
            if (gold >= item.price)
            {
                item.bought = true;
                SetGold(-item.price);
                onItemBought.Invoke(item);
            }
            else return;
        }

        switch (item.type)
        {
            case ItemType.clothes:
                if (activeClothes)
                {
                    PlayerController.instance.RemoveCharacterAnimator(activeClothes.characterAnimator);
                    activeClothes.gameObject.SetActive(false);
                }
                activeClothes = item;
                break;
            case ItemType.hair:
                if (activeHair)
                {
                    PlayerController.instance.RemoveCharacterAnimator(activeHair.characterAnimator);
                    activeHair.gameObject.SetActive(false);
                }
                activeHair = item;
                break;
            case ItemType.hat:
                if (activeHat)
                {
                    PlayerController.instance.RemoveCharacterAnimator(activeHat.characterAnimator);
                    activeHat.gameObject.SetActive(false);
                }
                activeHat = item;
                break;
        }

        item.gameObject.SetActive(true);
        PlayerController.instance.AddCharacterAnimator(item.characterAnimator);
    }

    public void SellItem(Item item)
    {
        if (item.bought)
        {
            item.bought = false;
            SetGold(item.price);

            switch (item.type)
            {
                case ItemType.clothes:
                    if (activeClothes == item)
                    {
                        PlayerController.instance.RemoveCharacterAnimator(activeClothes.characterAnimator);
                        activeClothes.gameObject.SetActive(false);
                        activeClothes = null;
                    }
                    break;
                case ItemType.hair:
                    if (activeHair == item)
                    {
                        PlayerController.instance.RemoveCharacterAnimator(activeHair.characterAnimator);
                        activeHair.gameObject.SetActive(false);
                        activeHair = null;
                    }
                    break;
                case ItemType.hat:
                    if (activeHat == item)
                    {
                        PlayerController.instance.RemoveCharacterAnimator(activeHat.characterAnimator);
                        activeHat.gameObject.SetActive(false);
                        activeHat = null;
                    }
                    break;
            }
        }
    }
}
