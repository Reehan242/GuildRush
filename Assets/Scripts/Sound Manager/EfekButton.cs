using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfekButton : MonoBehaviour
{
    public void Button()
    {
        AudioManager.instance.PlayEfek("Button");
    }

    public void Mulai_BGM_Main_dari_GuildScreen()
    {
        AudioManager.instance.StopBG("Backsound Guild Screen");
        AudioManager.instance.PlayBG("Backsound Main Screen");
    }
    public void Mulai_BGM_GuildScreen_dari_Main()
    {
        AudioManager.instance.StopBG("Backsound Main Screen");
        AudioManager.instance.PlayBG("Backsound Guild Screen");
    }
    public void Mulai_BGM_Guild_dari_Battle()
    {
        AudioManager.instance.StopBG("Backsound Battle Screen");
        AudioManager.instance.PlayBG("Backsound Guild Screen");
    }

    public void Mulai_BGM_Battle()
    {
        AudioManager.instance.StopBG("Backsound Guild Screen");
        AudioManager.instance.PlayBG("Backsound Battle Screen");
    }

}
