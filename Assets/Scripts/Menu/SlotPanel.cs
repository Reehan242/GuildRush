using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlotPanel : MonoBehaviour
{
    public int itemID;
    public AudioSource Audio_Efek;
    public AudioClip pressed;
    public List<EquipmentObject> items = new List<EquipmentObject>();


    private Scene currentScene;
    public void changeInventoryID() 
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "BlacksmithScreen")
        {
            changeBlacksmithItemID();
        }
        else
        {
            try
            {
                PlayerData dataPlayer = loadDataPlayer();
                EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");

                for (int j = 0; j < dataPlayer.uniqueID.Count; j++)
                {
                    EquipmentObject Equip = getEquip(allEquips, dataPlayer.equipID[j]); ;
                    EquipmentObject newEquip = Instantiate(Equip);
                    newEquip.uniqueID = dataPlayer.uniqueID[j];
                    items.Add(newEquip);
                }
                EquipmentObject equip = items.Find(obj => obj.uniqueID == itemID);
                PlayerEquipmentData dataEquip = dataPlayer.equipments.Find(obj => obj.uniqueID == itemID);
                equip.level = dataEquip.level;
                equip.hpBonus = dataEquip.hp;
                equip.atkBonus = dataEquip.Atk;
                equip.defBonus = dataEquip.Def;
                equip.spdBonus = dataEquip.Spd;
                GameObject inventory = GameObject.Find("Inventory");
                inventory.GetComponent<InventoryManager>().itemID = itemID;
                GameObject description = GameObject.Find("DescText");
                TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
                text.text = ("***" + equip.eqName + "***" + "\n\nLevel = " + equip.level + "\nHP Bonus = " + equip.hpBonus + "\nATK Bonus = " + equip.atkBonus
                             + "\nDEF Bonus = " + equip.defBonus + "\nSPD Bonus = " + equip.spdBonus);
                try
                {
                    /*var equipAssets = getEquipAsset(assets, equip.eqName);*/
                    GameObject cubeTest = GameObject.Find("PlaceCube");
                    spawnAssets displayAsset = cubeTest.GetComponent<spawnAssets>();
                    if (equip.type == ItemType.Weapon)
                    {
                        displayAsset.createDisplay(equip.prefab, equip);
                    }
                    else if (equip.type == ItemType.Armor)
                    {
                        displayAsset.createDisplay2(equip);
                    }
                    
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Terjadi kesalahan: " + e.Message);
                    GameObject cubeTest = GameObject.Find("PlaceCube");
                    spawnAssets displayAsset = cubeTest.GetComponent<spawnAssets>();
                    displayAsset.destroyAsset();
                    Debug.Log("Asset belum ada");
                }
            }
            catch 
            {
                GameObject inventory = GameObject.Find("Inventory");
                inventory.GetComponent<InventoryManager>().itemID = 0;
                GameObject description = GameObject.Find("DescText");
                TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
                text.text = ("");
                GameObject cubeTest = GameObject.Find("PlaceCube");
                spawnAssets displayAsset = cubeTest.GetComponent<spawnAssets>();
                displayAsset.destroyAsset();
                Debug.Log("Nothing Selected");

            }
        }
        
    }

    public void changeBlacksmithItemID()
    {
        try
        {
            PlayerData dataPlayer = loadDataPlayer();
            EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");

            for (int j = 0; j < dataPlayer.uniqueID.Count; j++)
            {
                EquipmentObject Equip = getEquip(allEquips, dataPlayer.equipID[j]); ;
                EquipmentObject newEquip = Instantiate(Equip);
                newEquip.uniqueID = dataPlayer.uniqueID[j];
                items.Add(newEquip);
            }
            EquipmentObject equip = items.Find(obj => obj.uniqueID == itemID);
            PlayerEquipmentData dataEquip = dataPlayer.equipments.Find(obj => obj.uniqueID == itemID);
            equip.level = dataEquip.level;
            equip.hpBonus = dataEquip.hp;
            equip.atkBonus = dataEquip.Atk;
            equip.defBonus = dataEquip.Def;
            equip.spdBonus = dataEquip.Spd;
            var cost = price(equip.ID, equip.type, EquipmentData.cost);
            GameObject inventory = GameObject.Find("Inventory");
            inventory.GetComponent<InventoryManager>().itemID = itemID;
            GameObject description = GameObject.Find("DescText");
            GameObject description2 = GameObject.Find("DescText 2");
            if (equip.type == ItemType.Weapon)
            {
                
                TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI text2 = description2.GetComponent<TextMeshProUGUI>();
                if (equip.level < 20)
                {
                    text.text = ("***" + equip.eqName + "***" + "\n\nLevel : " + equip.level + "\nHP Bonus : " + equip.hpBonus + "\nATK Bonus : " + equip.atkBonus
                            + "\nDEF Bonus : " + equip.defBonus + "\nSPD Bonus : " + equip.spdBonus);

                    text2.text = ("Next Level\n\nLevel : " + (equip.level + 1) + "\nHP Bonus : " + (equip.hpBonus) + "\nATK Bonus : " + (equip.atkBonus + GameData.statGrowth[0, equip.ID - 1])
                                 + " (+" + GameData.statGrowth[0, equip.ID - 1] + ")\nDEF Bonus : " + (equip.defBonus + GameData.statGrowth[1, equip.ID - 1]) + " (+" + GameData.statGrowth[1, equip.ID - 1] + ")\nSPD Bonus : "
                                 + (equip.spdBonus + GameData.statGrowth[2, equip.ID - 1]) + " (+" + GameData.statGrowth[2, equip.ID - 1] + ")\n\nCost : " + (equip.level * 0.5 * cost));
                }
                else
                {
                    text.text = ("***" + equip.eqName + "***" + "\n\nLevel : " + equip.level + "\nHP Bonus : " + equip.hpBonus + "\nATK Bonus : " + equip.atkBonus
                            + "\nDEF Bonus : " + equip.defBonus + "\nSPD Bonus : " + equip.spdBonus);

                    text2.text = ("Max Level");
                }
               
            }
            else
            {
                TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI text2 = description2.GetComponent<TextMeshProUGUI>();
                text.text = ("This Item Is Not Available For Upgrade");
                text2.text = ("");
            }
            
        }
        catch
        {
            GameObject inventory = GameObject.Find("Inventory");
            inventory.GetComponent<InventoryManager>().itemID = 0;
            GameObject description = GameObject.Find("DescText");
            GameObject description2 = GameObject.Find("DescText 2");
            TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI text2 = description2.GetComponent<TextMeshProUGUI>();
            text.text = ("");
            text2.text = ("");
            Debug.Log("Nothing Selected");
        }
    }
   
    public void ClickSound()
    {
        Audio_Efek.PlayOneShot(pressed);
    }
    public PlayerData loadDataPlayer()
    {
        GameData.Initialize();
        PlayerData dataPlayer = GameData.Player;
        
        return dataPlayer;
    }

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

}
