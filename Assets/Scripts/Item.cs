using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ItemType
{
    clothes,
    hair,
    hat
}

public class Item : MonoBehaviour
{
    public int price;
    public Animator characterAnimator;
    public ItemType type;
    [HideInInspector] public bool bought;
}
