using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject MunculPause;
    public GameObject MunculMenu;
    public GameObject MunculUI;
    public GameObject HilangSetting;
    public GameObject HilangTentang;
    public Animation AnimasiCredit;

    public void MenuMuncul()
    {
        MunculPause.SetActive(false);
        MunculMenu.SetActive(true);
    }

    public void PauseMuncul()
    {
        MunculPause.SetActive(true);
        MunculMenu.SetActive(false);
    }

    public void SettingHilang()
    {
        HilangSetting.SetActive(false);
        MunculUI.SetActive(true);
    }

    public void TentangHilang()
    {
        HilangTentang.SetActive(false);
        MunculUI.SetActive(true);
    }

    public void Mulai_BGM_Credit()
    {
        AudioManager.instance.StopBG("Backsound Main Screen");
        AudioManager.instance.PlayBG("Backsound Credit Screen");
        AnimasiCredit.GetComponent<Animation>().Rewind();
    }

    public void Mulai_BGM_MainScreen()
    {
        AudioManager.instance.StopBG("Backsound Credit Screen");
        AudioManager.instance.PlayBG("Backsound Main Screen");
    }


}
