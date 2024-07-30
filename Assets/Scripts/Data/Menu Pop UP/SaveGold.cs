using UnityEngine;
using UnityEngine.UI;

public class SaveGold : MonoBehaviour
{
    [SerializeField] public int GoldPlayer;
    [SerializeField] public Text LoadGold;

    void Start()
    {

        GoldPlayer = PlayerPrefs.GetInt("GoldPlayer", 0);
        LoadGold.text = GoldPlayer.ToString();
    }

    public void SaveGoldValue()
    {
        PlayerPrefs.SetInt("GoldPlayer", GoldPlayer);
    }

    public void AddGold(int amount)
    {
        GoldPlayer += amount;
        SaveGoldValue(); 
        LoadGold.text = GoldPlayer.ToString(); 
    }

    public void MinGold(int amount)
    {
        GoldPlayer -= amount;
        if (GoldPlayer < 0)
        {
            GoldPlayer = 0;
        }
        SaveGoldValue();
        LoadGold.text = GoldPlayer.ToString();
    }
}
