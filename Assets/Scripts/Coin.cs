using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] Text textValue;
    [SerializeField] SpriteRenderer coin;

    bool collected;

    private void Start()
    {
        textValue.text = "+" + value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        GameManager.instance.SetGold(value);
        collected = true;

        coin.enabled = false;
        StartCoroutine(Animation());

        Destroy(gameObject, 1);
    }

    IEnumerator Animation()
    {
        textValue.gameObject.SetActive(true);

        while (true)
        {
            textValue.transform.position += Vector3.up * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
