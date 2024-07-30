using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;
using TMPro;
using Newtonsoft.Json;

[Serializable]
public class PlayerDataDataObject
{
    public int GoldPlayer;
    public string NamaPlayer;
    public int RankPlayer;
    public List<int> EquipmentID;
    public List<int> uniqueID;
    public int uniqueIDCounter;
    public List<AdventurerData> adventurerlist;
    

    public List<int> equipID { get; internal set; }
}

public class MenuPopUpData : MonoBehaviour
{
    public int SavedGoldPlayer;
    public string SavedNamaPlayer;
    public int SavedRankPlayer;
    public int uniqueIDCounter;
    public List<int> uniqueID;
    public List<int> equipID;
    public GameObject MuatData;
    public GameObject MunculMenu;
    public GameObject MunculBuatData;
    public TMP_InputField TxtInput;
    public List<AdventurerData> adventurerList;
    

    public const string fileName = "playerData.json";

    public TMP_Text LoadGold;
    public TMP_Text LoadNama;
    public TMP_Text LoadRank;

    void Start()
    {
        LoadDataFromJson();
    }

    void Update()
    {

    }

    [ContextMenu("SaveDataToJson")]
    public void SaveDataToJson()
    {
        PlayerDataDataObject dataObject = new PlayerDataDataObject
        {
            GoldPlayer = SavedGoldPlayer,
            NamaPlayer = SavedNamaPlayer,
            RankPlayer = SavedRankPlayer,
            EquipmentID = equipID,
            uniqueID = uniqueID,
            uniqueIDCounter = uniqueIDCounter,
            adventurerlist = adventurerList,
            
        };


        string jsonData = JsonConvert.SerializeObject(dataObject);

        File.WriteAllText(Application.dataPath + "/" + fileName, jsonData);


        Debug.Log("Data saved to JSON: " + jsonData);
    }

    public void LoadDataFromJson()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/" + fileName);

        PlayerDataDataObject dataObject = JsonConvert.DeserializeObject<PlayerDataDataObject>(jsonData);
        SavedGoldPlayer = dataObject.GoldPlayer;
        SavedNamaPlayer = dataObject.NamaPlayer;
        SavedRankPlayer = dataObject.RankPlayer;
        equipID = dataObject.EquipmentID;
        uniqueID = dataObject.uniqueID;
        uniqueIDCounter = dataObject.uniqueIDCounter;
        adventurerList = dataObject.adventurerlist;
        



        if (LoadGold != null && LoadNama != null && LoadRank != null)
        {
            LoadGold.text = ("Gold : " + dataObject.GoldPlayer.ToString("N0"));
            LoadNama.text = dataObject.NamaPlayer;
            LoadRank.text = ("Rank : " + GetRankString(dataObject.RankPlayer));
        }

    }

    public void PilihData()
    {
        string filePath = Path.Combine(Application.dataPath + "/" + fileName);

        if (File.Exists(filePath))
        {
            MuatData.SetActive(true);
            MunculMenu.SetActive(false);
        }
        else
        {
            PlayerDataDataObject dataObject = new PlayerDataDataObject
            {
                GoldPlayer = 500,
                NamaPlayer = TxtInput.text,
                RankPlayer = 0,
                equipID = new List<int>(),
                uniqueID = new List<int>(),
                uniqueIDCounter = 1,
                adventurerlist = new List<AdventurerData> { AddDefaultAdventurer1(), AddDefaultAdventurer2(), AddDefaultAdventurer3() },
                
            };

            string jsonData = JsonConvert.SerializeObject(dataObject);
            Debug.Log("Data saved to JSON: " + jsonData);
            File.WriteAllText(filePath, jsonData);
            MunculBuatData.SetActive(true);
            MunculMenu.SetActive(false);
        }
    }


    public void NewSaveData()
    {
        PlayerDataDataObject dataObject = new PlayerDataDataObject
        {
            GoldPlayer = 500,
            NamaPlayer = TxtInput.text,
            RankPlayer = 0,
            equipID = new List<int>(),
            uniqueID = new List<int>(),
            uniqueIDCounter = 1,
            adventurerlist = new List<AdventurerData> { AddDefaultAdventurer1(),AddDefaultAdventurer2(), AddDefaultAdventurer3()},
            
        };

        // Add three default adventurers


        string jsonData = JsonConvert.SerializeObject(dataObject);

        File.WriteAllText(Application.dataPath + "/" + fileName, jsonData);
    }

    private AdventurerData AddDefaultAdventurer1()
    {
        AdventurerData adventurer = new AdventurerData
        {
            Name = "Starter 1",
            Class = "Warrior",
            Rank = "F",
            Gender = 1,
            Atk = UnityEngine.Random.Range(1, 11),
            Def = UnityEngine.Random.Range(1, 11),
            Spd = UnityEngine.Random.Range(1, 11),
            equipedWeapon = 0,
            equipedArmor = 0,
            hairType = 1,
            TraitId = new List<int>() { },
        };
        return adventurer;
    }

    private AdventurerData AddDefaultAdventurer2()
    {
        AdventurerData adventurer = new AdventurerData
        {
            Name = "Starter 2",
            Class = "Archer",
            Rank = "F",
            Gender = 1,
            Atk = UnityEngine.Random.Range(1, 11),
            Def = UnityEngine.Random.Range(1, 11),
            Spd = UnityEngine.Random.Range(1, 11),
            equipedWeapon = 0,
            equipedArmor = 0,
            hairType = 2,
            TraitId = new List<int>() { }
        };
        return adventurer;
    }

    private AdventurerData AddDefaultAdventurer3()
    {
        AdventurerData adventurer = new AdventurerData
        {
            Name = "Starter 3",
            Class = "Knight",
            Rank = "F",
            Gender = 0,
            Atk = UnityEngine.Random.Range(1, 11),
            Def = UnityEngine.Random.Range(1, 11),
            Spd = UnityEngine.Random.Range(1, 11),
            equipedWeapon = 0,
            equipedArmor = 0,
            hairType = 5,
            TraitId = new List<int>() { }
        };
        return adventurer;
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

    public void Awake()
    {
        LoadDataFromJson();
    }

}