using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public delegate void PurchaseHandler();
    public static event PurchaseHandler PurchasedItem;

    public void buyClicked()
    {
        PurchasedItem();
    }
}
