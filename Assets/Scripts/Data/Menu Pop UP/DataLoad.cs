using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoad : MonoBehaviour
{

    public GameObject MunculDataLoad;
    public GameObject MunculMenu;

    public void MenuMuncul()
    {
        MunculDataLoad.SetActive(false);
        MunculMenu.SetActive(true);
    }


    public void DataMuncul()
    {
        MunculDataLoad.SetActive(true);
        MunculMenu.SetActive(false);
    }
}
