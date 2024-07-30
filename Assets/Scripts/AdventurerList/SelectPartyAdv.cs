using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPartyAdv : MonoBehaviour
{

    public PlayerData loadDataPlayer()
    {
        GameData.Initialize();
        PlayerData dataPlayer = GameData.Player;

        return dataPlayer;
    }

    public void SelectAdv(ItemButton itemButton)
    {
        PlayerData dataPlayer = loadDataPlayer();
        AdventurerChoose adventurerChoose = FindObjectOfType<AdventurerChoose>();
        if (adventurerChoose != null)
        {
            int idAdv = adventurerChoose.advID;
            if(idAdv >= 0 && idAdv < dataPlayer.Party.Length)
            {
                int selectedAdventurerIdx = itemButton.adventurerIdx;
                if (!ArrayContains(dataPlayer.Party, selectedAdventurerIdx))
                {
                    dataPlayer.Party[idAdv] = selectedAdventurerIdx;
                    PlayerData.SaveDataToJson(dataPlayer);
                }
                else Debug.LogError("Adventurer ID " + selectedAdventurerIdx + " is already in the party.");
            }
            else Debug.LogError("Invalid selected adventurer ID: " + idAdv);

            adventurerChoose.ClosePanel();
        }
    }

    private bool ArrayContains(int[] array, int value)
    {
        foreach (int element in array) if (element == value) return true;
        return false;
    }
}
