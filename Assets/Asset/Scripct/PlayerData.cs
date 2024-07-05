using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }

    public int GoldPlayer;
    public string NamaPlayer;
    public int RankPlayer;
    public List<EquipmentObject> equipmentItems;
    
    public int[,] cost = { { 400, 800, 1350, 2500, 4000, 5750, 8750, 15600 }, { 300, 700, 1200, 2250, 4000, 6325, 10500, 20800 } };

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public EquipmentObject[] loadAllEquip()
    {
        EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");
        return allEquips;
    }

    [ContextMenu("SaveDataToJson")]
    public void SaveDataToJson()
    {
        PlayerDataDataObject dataObject = new PlayerDataDataObject
        {
            GoldPlayer = GoldPlayer,
            NamaPlayer = NamaPlayer,
            RankPlayer = RankPlayer,
            items = equipmentItems
        };

        string jsonData = JsonUtility.ToJson(dataObject);

        File.WriteAllText(Application.dataPath + "/playerData.json", jsonData);

        Debug.Log("Data saved to JSON: " + jsonData);
    }

    public void LoadDataFromJson()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/playerData.json");

        PlayerDataDataObject dataObject = JsonUtility.FromJson<PlayerDataDataObject>(jsonData);
        GoldPlayer = dataObject.GoldPlayer;
        NamaPlayer = dataObject.NamaPlayer;
        RankPlayer = dataObject.RankPlayer;
        equipmentItems = dataObject.items;
        /*equipmentItems = dataObject.items;*/

        Debug.Log("Data loaded from JSON: " + jsonData);
    }

    public string GetRankString(int rank)
    {
        switch (rank)
        {
            case 0: return "F";
            case 1: return "E";
            case 2: return "D";
            case 3: return "C";
            case 4: return "B";
            case 5: return "A";
            case 6: return "S";
            case 7: return "SS";
            case 8: return "SSS";
            default: return "Unknown";
        }
    }
}

[Serializable]
public class PlayerDataDataObject
{
    public int GoldPlayer;
    public string NamaPlayer;
    public int RankPlayer;
    public List<EquipmentObject> items;
}


