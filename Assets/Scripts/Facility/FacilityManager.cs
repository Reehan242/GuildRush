using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class FacilityManager : MonoBehaviour
{
    public FacilityData[] loadAllFacility()
    {
        FacilityData[] allFacility = Resources.LoadAll<FacilityData>("Facility");
        return allFacility;

    }
}


/*
public FacilityData[] FacilityDataSO;
public FacilityTemplate[] FacilityPanels;
public GameObject[] FacilityPanelsGO;
public Button[] UpgradeFacilityBtn;
public int gold = 0;


void Start()
{
    for (int i = 0; i < FacilityDataSO.Length; i++)
        FacilityPanelsGO[i].SetActive(true);
    LoadPanels();
    CheckPurchaseable();
}

public void CheckPurchaseable()

{

    for (int i = 0;i < FacilityDataSO.Length;i++)
    {
        if (gold >= FacilityDataSO[i].upgradeCost[FacilityDataSO[i].Level])
        {
            UpgradeFacilityBtn[i].interactable = true;
        }
        else
        {
            UpgradeFacilityBtn[i].interactable = false;
        }

    }
}


public void UpgradeFacility(int btnNo)
{
        if (gold >= FacilityDataSO[btnNo].upgradeCost[FacilityDataSO[btnNo].Level])
        {
            gold = gold - FacilityDataSO[btnNo].upgradeCost[FacilityDataSO[btnNo].Level];
            FacilityDataSO[btnNo].Level++;
            LoadPanels();
            CheckPurchaseable();


    }

}
    public void LoadPanels()
    {
        for (int i = 0; i < FacilityDataSO.Length; i++)
        {
            FacilityPanels[i].titleTxt.text = FacilityDataSO[i].facilityName;
            FacilityPanels[i].levelTxt.text = FacilityDataSO[i].Level.ToString();
            FacilityPanels[i].costTxt.text = FacilityDataSO[i].upgradeCost[FacilityDataSO[i].Level].ToString();
        }

    }
    }*/