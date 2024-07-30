using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject MunculSetting;
    public GameObject MunculMenu;

    public void MenuMuncul()
    {
        MunculSetting.SetActive(false);
        MunculMenu.SetActive(true);
    }


    public void SettingMuncul()
    {
        MunculSetting.SetActive(true);
        MunculMenu.SetActive(false);
    }

}
