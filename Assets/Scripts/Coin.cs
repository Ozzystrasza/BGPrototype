using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.SetGold(value);

        Destroy(gameObject);
    }
}
