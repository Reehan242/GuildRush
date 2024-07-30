using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TestDataStats : MonoBehaviour
{

    public GameObject[] facilityBtn;
    public FacilityData[] facilityData;
    public PlayerDataViewer playerviewer;



    public void Start()
    {
        GameData.Initialize();

        gantitext();


    }
    public void UpgradeFacility(FacilityData facilityData, FacilityButton facilityButton) 
    {
        int facilityLevel = GameData.Player.playerFacilityData.GetFacilityLevel(facilityData.facilityID);
        if (facilityLevel < facilityData.maxLevel)
        {
            if (GameData.Player.GoldPlayer >= facilityData.upgradeCost[facilityLevel])
            {
                GameData.Player.GoldPlayer -= facilityData.upgradeCost[facilityLevel];
                GameData.Player.playerFacilityData.UpgradeFacility(facilityData.facilityID);

                facilityButton.initialize(facilityLevel);
                playerviewer.updatetext(GameData.Player); 

                PlayerData.SaveDataToJson(GameData.Player); //simpan data player }


            }
        }
    }

 
 

    public void gantitext()
    {

        for (int i = 0; i < facilityBtn.Length; i++) 
        {
            FacilityButton Btn = facilityBtn[i].GetComponent<FacilityButton>();
            int facilityLevel = GameData.Player.playerFacilityData.GetFacilityLevel(Btn.facilityData.facilityID);
            Btn.initialize(facilityLevel);
            

        }

    }
}




































/*public void Start()
{
    GameObject data = GameObject.Find("AllData");
    playerData = data.GetComponent<PlayerData>();
    playerData.LoadDataFromJson();
    gantitext();
    *//*      playerData.playerFacilityData.GetFacilityLevel()*//*

}
public void UpgradeFacility(FacilityData facilityData, FacilityButton facilityButton)
{
    if (playerData.GoldPlayer >= facilityData.upgradeCost[playerData.playerFacilityData.GetFacilityLevel(facilityData.facilityID)])
    {
        playerData.GoldPlayer -= facilityData.upgradeCost[playerData.playerFacilityData.GetFacilityLevel(facilityData.facilityID)];
        playerData.playerFacilityData.UpgradeFacility(facilityData.facilityID);

        facilityButton.initialize(playerData.playerFacilityData.GetFacilityLevel(facilityData.facilityID));

        playerData.SaveDataToJson(); //simpan data player
    }

}
public void gantitext()
{
    for (int i = 0; i < facilityBtn.Length; i++)
    {
        FacilityButton Btn = facilityBtn[i].GetComponent<FacilityButton>();
        int facilityLevel = playerData.playerFacilityData.GetFacilityLevel(Btn.facilityData.facilityID);
        Btn.initialize(facilityLevel);


    }

}
}
*/










