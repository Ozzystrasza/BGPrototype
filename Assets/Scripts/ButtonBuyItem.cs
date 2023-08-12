using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuyItem : MonoBehaviour
{
    [SerializeField] Text price;
    [SerializeField] Item itemToBuy;

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
        if (item == itemToBuy) HidePrice();
    }

    void HidePrice()
    {
        price.gameObject.SetActive(false);
    }
}
