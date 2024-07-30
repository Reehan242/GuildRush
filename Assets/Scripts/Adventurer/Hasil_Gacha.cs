using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hasil_Gacha : MonoBehaviour
{

    public GameObject Muncul;
    public GameObject Ilang;
    public GameObject SizeAdvent;
    public int sizeAdvent;

    public void BannerGacha()
    {
        Ilang.SetActive(true);
        Muncul.SetActive(false);
    }

    public void HasilGacha()
    {
        Ilang.SetActive(false);
        Muncul.SetActive(true);
    }

    public void buttonGacha()
    {
        if (GameData.Player.adventurerList.Count >= sizeAdvent)
        {
            SizeAdvent.SetActive(true);
        }
        else
        {
            FindObjectOfType<CharaList>().PencetGacha();
            Ilang.SetActive(false);
            Muncul.SetActive(true);
        }
    }
}