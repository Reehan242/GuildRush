using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public GameObject message = null;
    public int itemID;
    public bool locked=false;
    private int maxSlot = 60; 
     
    
    public void buyEquip()
    {
        
        if (itemID != 0)
        {
            if (!locked)
            {
                /*EquipmentData dataequip = loadDataEquip();*/
                EquipmentObject[] allEquips = EquipmentData.loadAllEquip();
                PlayerData dataPlayer = GameData.Player;
                
                var equip = getEquip(allEquips, itemID);
                var cost = price(equip.ID, equip.type, EquipmentData.cost);
                if (cost <= dataPlayer.GoldPlayer)
                {
                    if (dataPlayer.uniqueID.Count < maxSlot)
                    {
                        dataPlayer.GoldPlayer -= cost;
                        dataPlayer.equipID.Add(itemID);
                        dataPlayer.uniqueID.Add(dataPlayer.uniqueIDCounter);
                        equip.uniqueID = dataPlayer.uniqueIDCounter;
                        dataPlayer.uniqueIDCounter += 1;
                        dataPlayer.AddEquipment(equip);
                        //UnityEditor.AssetDatabase.CreateAsset(newEquip, AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Inventory/" + "NewItem.asset"));
                        PlayerData.SaveDataToJson(GameData.Player);
                        message.SetActive(true);
                        message.GetComponentInChildren<TextMeshProUGUI>().text = ("You've successfully purchased " + equip.eqName);
                        StartCoroutine(hideMessage());
                    }
                    else 
                    {
                        message.SetActive(true);
                        message.GetComponentInChildren<TextMeshProUGUI>().text = ("Your Inventory Is Full");
                        StartCoroutine(hideMessage());
                    }
                    

                }
                else
                {
                    message.SetActive(true);
                    message.GetComponentInChildren<TextMeshProUGUI>().text = ("Insufficient funds...");
                    StartCoroutine(hideMessage());
                    /*Debug.Log("Insufficient funds");*/
                }
            }
            else 
            {
                message.SetActive(true);
                message.GetComponentInChildren<TextMeshProUGUI>().text = ("Item Not Unlocked Yet...");
                StartCoroutine(hideMessage());
            }
            
        }
        else 
        {
            message.SetActive(true);
            message.GetComponentInChildren<TextMeshProUGUI>().text = ("No Item Selected...");
            StartCoroutine(hideMessage());
        }
        
    }
    /*public EquipmentData loadDataEquip()
    {
        GameObject equipData = GameObject.Find("allData");
        EquipmentData dataequip = equipData.GetComponent<EquipmentData>();
        return dataequip;
    }*/
    

    private EquipmentObject getEquip(EquipmentObject[] equips, int itemID)
    {

        foreach (var equip in equips)
        {
            if (equip.ID == itemID)
            {
                return equip;
            }

        }
        throw new System.Exception("no equipment found with ID " + itemID);

    }
    public int price(int ID, ItemType eqType, int[,] _itemCost)
    {
        var cost = 0;
        var itemCost = _itemCost;
        switch (eqType)
        {
            case ItemType.Weapon:

                if (ID < 8)
                {
                    cost = itemCost[0, 0];
                }
                else if (ID < 15)
                {
                    cost = itemCost[0, 1];
                }
                else if (ID < 22)
                {
                    cost = itemCost[0, 2];
                }
                else if (ID < 29)
                {
                    cost = itemCost[0, 3];
                }
                else if (ID < 36)
                {
                    cost = itemCost[0, 4];
                }
                else if (ID < 43)
                {
                    cost = itemCost[0, 5];
                }
                else if (ID < 50)
                {
                    cost = itemCost[0, 6];
                }
                else if (ID < 57)
                {
                    cost = itemCost[0, 7];
                }
                break;
            case ItemType.Armor:

                if (ID < 8)
                {
                    cost = itemCost[1, 0];
                }
                else if (ID < 15)
                {
                    cost = itemCost[1, 1];
                }
                else if (ID < 22)
                {
                    cost = itemCost[1, 2];
                }
                else if (ID < 29)
                {
                    cost = itemCost[1, 3];
                }
                else if (ID < 36)
                {
                    cost = itemCost[1, 4];
                }
                else if (ID < 43)
                {
                    cost = itemCost[1, 5];
                }
                else if (ID < 50)
                {
                    cost = itemCost[1, 6];
                }
                else if (ID < 57)
                {
                    cost = itemCost[1, 7];
                }
                break;
        }

        return cost;
    }

    public void updateGoldLabel() 
    {
        GameData.Initialize();
        PlayerData dataPlayer = GameData.Player;
        
        TextMeshProUGUI playerGoldText = GameObject.Find("Player Gold Label").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI playerNameText = GameObject.Find("Player Name Label").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI playerRankText = GameObject.Find("Player Rank Label").GetComponent<TextMeshProUGUI>();
        
        playerNameText.text = (dataPlayer.NamaPlayer);
        playerRankText.text = ("Rank : " + dataPlayer.GetRankString(dataPlayer.RankPlayer));
        playerGoldText.text = ("Gold : " + dataPlayer.GoldPlayer);
    }
    public void Update()
    {
        updateGoldLabel();
    }

    private IEnumerator hideMessage()
    {
        yield return new WaitForSeconds(4);
        message.SetActive(false);
    }
    private void Awake()
    {
        message.SetActive(false);
    }
}
