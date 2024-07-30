using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class rategacha : MonoBehaviour
{
    public static PlayerData player;
    public TMP_Text LoadRate;
    public TMP_Text LoadTrait;
    public TMP_Text Price;
    void Start()
    {
        GameData.Initialize();
        RateRank(GameData.Player);
        DisplayTraitProbabilities(GameData.traitData);

    }

    void Update()
    {

    }

    public void RateRank(PlayerData player)
    {

        if (player != null)
        {
            Price.text =  "( " + (500 + player.RankPlayer * 750 + 125*player.RankPlayer*player.RankPlayer)+" Gold)";
            switch (player.RankPlayer)
            {
                case 0:
                    LoadRate.text = player.GetRankString(player.RankPlayer) + "-Tier Banner Attribute probabilities : \nF Rank = 95%\nE Rank = 5%";
                    break;

                case 1:
                    LoadRate.text = player.GetRankString(player.RankPlayer) + "-Tier Banner Attribute probabilities : \nF Rank = 10%\nE Rank = 90%";  
                    break;

                case 2:
                    LoadRate.text = player.GetRankString(player.RankPlayer) + "-Tier Banner Attribute probabilities : \nD Rank = 85%\nF Rank = 5%\nE Rank = 10%";
                    break;

                case 3:
                    LoadRate.text = player.GetRankString(player.RankPlayer) + "-Tier Banner Attribute probabilities : \nC Rank = 80%\nD Rank = 15%\nE Rank = 5%";
                    break;

                case 4:
                    LoadRate.text = player.GetRankString(player.RankPlayer) + "-Tier Banner Attribute probabilities : \nB Rank = 75%\nC Rank = 20%\nD Rank = 10%";
                    break;

                case 5:
                    LoadRate.text = player.GetRankString(player.RankPlayer) + "-Tier Banner Attribute probabilities : \nA Rank = 75%\nB Rank = 20%\nC Rank = 10%";
                    break;

                case 6:
                    LoadRate.text = player.GetRankString(player.RankPlayer) + "-Tier Banner Attribute probabilities : \nS Rank = 60%\nA Rank = 25%\nB Rank = 10%\nC Rank = 5%";
                    break;

                case 7:
                    LoadRate.text = player.GetRankString(player.RankPlayer) + "-Tier Banner Attribute probabilities : \nSS Rank = 60%\nS Rank = 25%\nA Rank = 10%\nB Rank = 5%";
                    break;

                case 8:
                    LoadRate.text = player.GetRankString(player.RankPlayer) + "-Tier Banner Attribute probabilities : \nSSS Rank = 5%\nSS Rank = 60%\nS Rank = 25%\nA Rank = 10%";
                    break;

                default:
                    break;
            }
        }
        else
        {
            Debug.LogError("Player object is null. Make sure to initialize it.");
        }
    }

    private void DisplayTraitProbabilities(TraitDataBase[] traitData)
    {
        var traitProbabilities = traitData.Select(trait =>
            $"{trait.TraitName}").ToList();

        LoadTrait.text = $"Obtainable Traits:\n{string.Join(" || ", traitProbabilities)}";
    }

}

