using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int gold;

    public int Gold { get => gold; set => gold = value; }

    [HideInInspector] public UnityEvent<int> onChangedGold;

    private void Awake()
    {
        instance = this;
    }

    public void SetGold(int value)
    {
        gold += value;
        onChangedGold.Invoke(gold);
    }
}
