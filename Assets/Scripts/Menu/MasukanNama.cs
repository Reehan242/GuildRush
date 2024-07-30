using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasukanNama : MonoBehaviour
{
    public GameObject MunculMasukanNama;
    public GameObject MunculMenu;

    public void MenuMuncul()
    {
        MunculMasukanNama.SetActive(false);
        MunculMenu.SetActive(true);
    }

    public void MasukanNamaMuncul()
    {
        MunculMasukanNama.SetActive(true);
        MunculMenu.SetActive(false);
    }
}
