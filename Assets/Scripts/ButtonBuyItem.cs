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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
