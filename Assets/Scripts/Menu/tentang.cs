using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class tentang : MonoBehaviour
{

    public GameObject MunculTentang;
    public GameObject MunculMenu;

    public void MenuMuncul()
    {
        MunculTentang.SetActive(false);
        MunculMenu.SetActive(true);
    }


    public void TentangMuncul()
    {
        MunculTentang.SetActive(true);
        MunculMenu.SetActive(false);
    }
}
