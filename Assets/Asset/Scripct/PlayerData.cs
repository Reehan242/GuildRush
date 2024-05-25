using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public int GoldPlayer;
    public string NamaPlayer;
    public int RankPlayer;

    /*public Text LoadGold;
    public Text LoadNama;
    public Text LoadRank;*/

    [ContextMenu("SaveDataToJson")]
    public void SaveDataToJson()
    {
        // Create a data object and populate it with current data
        PlayerDataDataObject dataObject = new PlayerDataDataObject
        {
            GoldPlayer = GoldPlayer,
            NamaPlayer = NamaPlayer,
            RankPlayer = RankPlayer
        };

        // Convert the data object to JSON
        string jsonData = JsonUtility.ToJson(dataObject);

        // Save the JSON data to a file
        File.WriteAllText(Application.dataPath + "/playerData.json", jsonData);

        Debug.Log("Data saved to JSON: " + jsonData);
    }

    public void LoadDataFromJson()
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/playerData.json");

        PlayerDataDataObject dataObject = JsonUtility.FromJson<PlayerDataDataObject>(jsonData);
        GoldPlayer = dataObject.GoldPlayer;
        NamaPlayer= dataObject.NamaPlayer;
        RankPlayer = dataObject.RankPlayer; 

        /*LoadGold.text = dataObject.GoldPlayer.ToString();
        LoadNama.text = dataObject.NamaPlayer;
        LoadRank.text = dataObject.RankPlayer;*/

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

[Serializable]
public class PlayerDataDataObject
{
    public int GoldPlayer;
    public string NamaPlayer;
    public int RankPlayer;
}


