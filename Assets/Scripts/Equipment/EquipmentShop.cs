using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentShop : MonoBehaviour
{
    public AudioSource Audio_Efek;
    public AudioClip pressed;
    public int itemID;
    public TextMeshProUGUI text;
    public bool locked;
    private Image sourceImage;
    public Sprite equipIcon;

    private void Start()
    {
        Sprite[] allEquipIcon = Resources.LoadAll<Sprite>("Assets/Equipment Icon");
        Transform childImage = transform.Find("Image");
        sourceImage = childImage.GetComponent<Image>();
        /*EquipmentData dataequip = loadDataEquip();*/
        EquipmentObject[] allEquips = EquipmentData.loadAllEquip();
        changeColor();
        foreach(Sprite a in allEquipIcon)
        {
            if (getEquip(allEquips, itemID).equipmentType == eqType.heavyArmor)
            {
                if (a.name == "sample_heavyarmor")
                {
                    equipIcon = a; break;
                }
            }
            else if (getEquip(allEquips, itemID).equipmentType == eqType.lightArmor)
            {
                if (a.name == "sample_lightarmor")
                {
                    equipIcon = a; break;
                }
            }
            else
            {
                if (a.name == getEquip(allEquips, itemID).eqName)
                {
                    equipIcon = a; break;
                }
            }
            
        };
        GameObject[] assets = EquipmentData.loadEquipAssets();
        text.text = (getEquip(allEquips,itemID).eqName);
        if (equipIcon == null)
        {
            Color colorC = sourceImage.color;
            colorC.a = 0.0f;
            sourceImage.color = colorC;
        }
        else
        {
            sourceImage.sprite = equipIcon;
        }
       
        
    }
    public void selectEquip()
    {
        /*EquipmentData dataequip = loadDataEquip();*/
        
        EquipmentObject[] allEquips = EquipmentData.loadAllEquip();
        /*GameObject[] assets = EquipmentData.loadEquipAssets();*/
        var equip = getEquip(allEquips, itemID);
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
        catch
        {
            GameObject cubeTest = GameObject.Find("PlaceCube");
            spawnAssets displayAsset = cubeTest.GetComponent<spawnAssets>();
            displayAsset.destroyAsset();
            Debug.Log("tao");
        }


        var cost = price(equip.ID, equip.type, EquipmentData.cost);
        GameObject description = GameObject.Find("Desc_Text");
        TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
        text.text =  ("***" + equip.eqName + "***"+ "\n\nHP Bonus = " + equip.hpBonus + "\nATK Bonus = " + equip.atkBonus
                     + "\nDEF Bonus = " + equip.defBonus + "\nSPD Bonus = " + equip.spdBonus+"\n\n\nPrice = "+ cost);
        BuyButton buy = GameObject.Find("Btn_Buy").GetComponent<BuyButton>();
        buy.itemID = itemID;
        buy.locked = checkLocked();
        
    }

    
    /*public EquipmentData loadDataEquip()
    {

        EquipmentData dataequip = new EquipmentData();
        return dataequip;
    }*/
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
    private GameObject getEquipAsset(GameObject[] equips, string eqName)
    {

        foreach (var equip in equips)
        {
            if (equip.name == eqName)
            {
                return equip;
            }

        }
        throw new System.Exception("no Assets found with name " + eqName);

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

    public void ClickSound()
    {
        Audio_Efek.PlayOneShot(pressed);
    }
    private bool checkLocked() 
    {
        bool locked;
        PlayerData playerData = loadDataPlayer();
        if (itemID < 8 && playerData.RankPlayer == 1)
        {
            locked = false;
        }
        else if (itemID < 15 && playerData.RankPlayer == 2)
        {
            locked = false;
        }
        else if (itemID < 22 && playerData.RankPlayer == 3) 
        {
            locked = false;
        }
        else if (itemID < 29 && playerData.RankPlayer == 4)
        {
            locked = false;
        }
        else if (itemID < 36 && playerData.RankPlayer == 5)
        {
            locked = false;
        }
        else if (itemID < 43 && playerData.RankPlayer == 6)
        {
            locked = false;
        }
        else if (itemID < 50 && playerData.RankPlayer == 7)
        {
            locked = false;
        }
        else if (itemID < 57 && playerData.RankPlayer == 8)
        {
            locked = false;
        }
        else
        {
            locked = true;
        }
        return locked;
    }

    private void changeColor() 
    {

        locked = checkLocked();
        Color colorC = gameObject.GetComponent<Image>().color;
        if (locked == true)
        {
            
            colorC.r = 0f;
            colorC.g = 0f;
            colorC.b = 0f;
            colorC.a = 0.85f;
            gameObject.GetComponent<Image>().color = colorC;
        }
        else
        {
            colorC.r = 1f;
            colorC.g = 1f;
            colorC.b = 1f;
            colorC.a = 0.0f;
            gameObject.GetComponent<Image>().color = colorC;
        }
    }

    private void Update()
    {
        changeColor();
    }
}
