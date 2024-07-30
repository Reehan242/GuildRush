using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSeting : MonoBehaviour
{
    [SerializeField]
    public Slider sliderMusik;
    public Slider sliderEfek;

    public void MusikSlider()
    {
        AudioManager.instance.MusikSlider(sliderMusik.value);
    }

    public void EfekSlider()
    {
        AudioManager.instance.EfekSlider(sliderEfek.value);
    }

}
