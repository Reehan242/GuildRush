using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEfect : MonoBehaviour
{

    public AudioSource Audio_Efek;
    public AudioClip hover;
    public AudioClip pressed;

    private void OnEnable()
    {
        BuyManager.PurchasedItem += ClickSound;
    }
    private void OnDisable()
    {
        BuyManager.PurchasedItem -= ClickSound;
    }
    public void HoverSound()
    {
        Audio_Efek.PlayOneShot(hover);
    }

    public void ClickSound()
    {
        Audio_Efek.PlayOneShot(pressed);
    }

}
