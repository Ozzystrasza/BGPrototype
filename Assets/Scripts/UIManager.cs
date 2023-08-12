using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text uiGold;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.onChangedGold.AddListener(ChangeGold);
    }

    void ChangeGold(int value)
    {
        uiGold.text = value.ToString();
    }


}
