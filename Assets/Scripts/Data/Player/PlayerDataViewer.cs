using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataViewer : MonoBehaviour
{
    public TMP_Text NameText;
    public TMP_Text RankText;
    public TMP_Text GoldText;

    void Start()
    {
        GameData.Initialize();
        updatetext(GameData.Player);
        
    }

    private void Update()
    {
        GameData.Initialize();
    }

    public void updatetext(PlayerData player)
    {
        NameText.text = player.NamaPlayer;
        RankText.text = "Rank : " + player.GetRankString(player.RankPlayer);
        GoldText.text = "Gold : " + player.GoldPlayer.ToString("N0");
    }
}

 