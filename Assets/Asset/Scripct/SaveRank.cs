using UnityEngine;
using UnityEngine.UI;

public class SaveRank : MonoBehaviour
{
    [SerializeField] public string RankPlayer = "F";
    [SerializeField] public Text LoadRank;

    void Start()
    {
        RankPlayer = PlayerPrefs.GetString("Rank.Player", "F");
        LoadRank.text = RankPlayer;
    }

    public void SaveRankPlayer()
    {
        PlayerPrefs.SetString("Rank.Player", RankPlayer);
    }

    public void LevelUp()
    {
        RankPlayer = RankUp(RankPlayer);
        SaveRankPlayer(); 
        LoadRank.text = RankPlayer; 
    }

    public void LevelDown()
    {
        RankPlayer = RankDown(RankPlayer);
        SaveRankPlayer();
        LoadRank.text = RankPlayer;
    }

    private string RankUp(string currentRank)
    {
        switch (currentRank)
        {
            case "F":
                return "E";
            case "E":
                return "D";
            case "D":
                return "C";
            case "C":
                return "B";
            case "B":
                return "A";
            case "A":
                return "S";
            case "S":
                return "SS";
            case "SS":
                return "SSS";
            default:
                return currentRank;
        }
    }

    private string RankDown(string currentRank)
    {
        switch (currentRank)
        {
            case "SSS":
                return "SS";
            case "SS":
                return "S";
            case "S":
                return "A";
            case "A":
                return "B";
            case "B":
                return "C";
            case "C":
                return "D";
            case "D":
                return "E";
            case "E":
                return "F";
            case "F":
                return "F";
            default:
                return currentRank;
        }
    }
}

