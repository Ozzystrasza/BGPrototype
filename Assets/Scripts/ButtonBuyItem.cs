using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuyItem : MonoBehaviour
{
    [SerializeField] Text price;
    [SerializeField] Item itemToBuy;
    [SerializeField] Button sell;

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() => GameManager.instance.BuyItem(itemToBuy));

        GameManager.instance.onItemBought.AddListener(OnItemBought);

        price.text = "$" + itemToBuy.price;
    }

    void OnItemBought(Item item)
    {
        if (item == itemToBuy)
        {
            HidePrice();
            sell.gameObject.SetActive(true);
        }
    }

    void HidePrice()
    {
        price.gameObject.SetActive(false);
    }

    public void SellItem()
    {
        GameManager.instance.SellItem(itemToBuy);
        sell.gameObject.SetActive(false);
        price.gameObject.SetActive(true);
    }
}
