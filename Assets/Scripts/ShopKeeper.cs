using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] GameObject canvasInteraction;
    [SerializeField] GameObject uiShop;

    bool canInteract;

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canInteract = true;
        canvasInteraction.SetActive(canInteract);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canInteract = false;
        canvasInteraction.SetActive(canInteract);
        CloseShop();
    }

    public void OpenShop()
    {
        uiShop.SetActive(true);
        canvasInteraction.SetActive(false);
    }

    public void CloseShop()
    {
        uiShop.SetActive(false);
        if (canInteract) canvasInteraction.SetActive(true);
    }
}
