using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class PlayerEquipmentData
{
    public int uniqueID;
    public int equipID;
    public int level;
    public int hp;
    public int Atk;
    public int Def;
    public int Spd;
    public bool equipped;
}

[Serializable]
public class PlayerData
{
    public int GoldPlayer;
    public string NamaPlayer;
    public int RankPlayer;
    public int uniqueIDCounter;
    public List<int> uniqueID;
    public List<int> equipID;
    public List<PlayerEquipmentData> equipments = new();

    public PlayerFacilityData playerFacilityData = new();
    public List<AdventurerData> adventurerList = new();
    public List<int> ClearedQuestIds = new List<int>();
    public int[] Party = new int[3]
    {
        0,
        1,
        2
    };

    public const string fileName = "playerData.json";

    [ContextMenu("SaveDataToJson")]
    public static void SaveDataToJson(PlayerData playerData)
    {/*
        string jsonData = JsonUtility.ToJson(playerData);*/
        string jsonData = JsonConvert.SerializeObject(playerData);

        string path = Application.dataPath + "/" + fileName;
        File.WriteAllText(path, jsonData);
        Debug.Log("Data saved to JSON: " + path + " " + jsonData);
    }

    /*public static void ConvertEquipmentData(PlayerData playerData)
    {
        playerData.equipments = new List<PlayerEquipmentData>();
        for(int i = 0; i < playerData.uniqueID.Count; i++)
        {
            playerData.equipments.Add(new PlayerEquipmentData()
            {
                uniqueID = playerData.uniqueID[i],
                equipID = playerData.equipID[i]
            });
        }
    }*/

    public static PlayerData LoadDataFromJson()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/" + fileName);
        PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(jsonData);
        if (playerData.equipments == null)
        {
            playerData.equipments = new List<PlayerEquipmentData> { };
        }
        return playerData;
    }

    public string GetRankString(int rank)
    {
        switch (rank)
        {
            case 0:
                return "F";
            case 1:
                return "E";
            case 2:
                return "D";
            case 3:
                return "C";
            case 4:
                return "B";
            case 5:
                return "A";
            case 6:
                return "S";
            case 7:
                return "SS";
            case 8:
                return "SSS";
            default:
                return "Unknown";
        }
    }

    public void AddEquipment(EquipmentObject eqObj)
    {
        equipments.Add(new PlayerEquipmentData()
        {
            uniqueID = eqObj.uniqueID,
            equipID = eqObj.ID,
            level = eqObj.level,
            hp = eqObj.hpBonus,
            Atk = eqObj.atkBonus,
            Def = eqObj.defBonus,
            Spd = eqObj.spdBonus,
            equipped = false,
        });
    }
}
