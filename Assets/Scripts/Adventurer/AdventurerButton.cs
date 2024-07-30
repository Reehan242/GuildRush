using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventurerButton : MonoBehaviour
{
    public AdventurerData adventurerData;
    public int adventurerIdx;
    public PlayerData dataPlayer;

    public PlayerData LoadDataPlayer()
    {
        GameData.Initialize();
        PlayerData dataPlayer = GameData.Player;
        return dataPlayer;
    }

    public void Start()
    {
        dataPlayer = LoadDataPlayer();
    }

    public void Click()
    {
        Debug.Log("test debug!" + adventurerIdx); 
        Adventurerdetails adventurerDetails = FindObjectOfType<Adventurerdetails>();
        if (adventurerDetails != null && adventurerIdx >= 0 && adventurerIdx < GameData.Player.adventurerList.Count)
        {
            AdventurerData adventurerData = dataPlayer.adventurerList[adventurerIdx];
            //adventurerDetails.adventurerPopUp(adventurerData);
        }
    }
}
