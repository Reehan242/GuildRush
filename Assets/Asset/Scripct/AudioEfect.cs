using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEfect : MonoBehaviour
{

    public AudioSource Audio_Efek;
    public AudioClip hover;
    public AudioClip pressed;

    public void HoverSound()
    {
        Audio_Efek.PlayOneShot(hover);
    }

    public void ClickSound()
    {
        Audio_Efek.PlayOneShot(pressed);
    }

}
