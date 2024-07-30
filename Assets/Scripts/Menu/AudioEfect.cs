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
        if (hover != null)
        {
            Audio_Efek.PlayOneShot(hover);
        }
    }

    public void ClickSound()
    {
        if (pressed != null)
        {
            Audio_Efek.PlayOneShot(pressed);
        }
    }

}
