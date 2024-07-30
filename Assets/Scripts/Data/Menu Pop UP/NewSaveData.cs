using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class NewSaveData : MonoBehaviour
{
    public GameObject MunculBuatData;
    public GameObject MuatData;
    public GameObject MunculMenu;
    public TMP_InputField TxtInput;
    public MenuPopUpData playerData;
    public const string fileName = "playerData.json";

    private void Start()
    {
        playerData = FindObjectOfType<MenuPopUpData>();
    }

    private void Update()
    {
        playerData.LoadDataFromJson();
    }

    public void MenuMuncul()
    {
        MunculBuatData.SetActive(false);
        MunculMenu.SetActive(true);
    }

    public void PilihData()
    {
        string filePath = Application.dataPath + "/" + fileName;

        if (File.Exists(filePath))
        {
            playerData.LoadDataFromJson();
            MuatData.SetActive(true);
            MunculMenu.SetActive(false);
        }
        else
        {
            playerData.SavedNamaPlayer = TxtInput.text;
            playerData.SavedGoldPlayer = 0;
            playerData.SavedRankPlayer = 0;
            playerData.SaveDataToJson();
            MunculBuatData.SetActive(true);
            MunculMenu.SetActive(false);
        }
    }

    public void MasukanNamaPlayer()
    {
        playerData.SavedNamaPlayer = TxtInput.text;
        playerData.SaveDataToJson();
    }
}
