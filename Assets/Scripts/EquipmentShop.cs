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
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI descText;
    public bool locked;
    [SerializeField] private GameObject ButtonBuy;
    
   
    private void Start()
    {
        EquipmentObject[] allEquips = PlayerData.Instance.loadAllEquip();
        changeColor();
        text.text = (getEquip(allEquips,itemID).eqName);
        Debug.Log("start dipanggil");
    }
    public void selectEquip()
    {
        EquipmentObject[] allEquips = PlayerData.Instance.loadAllEquip();
        var equip = getEquip(allEquips, itemID);
        var cost = price(equip.ID, equip.type, PlayerData.Instance.cost);
        descText.text =  ("***" + equip.eqName + "***"+ "\n\nHP Bonus = " + equip.hpBonus + "\nATK Bonus = " + equip.atkBonus
                     + "\nDEF Bonus = " + equip.defBonus + "\nSPD Bonus = " + equip.spdBonus+"\n\n\nPrice = "+ cost);
        BuyButton buy = ButtonBuy.GetComponent<BuyButton>();
        buy.itemID = itemID;
        buy.locked = checkLocked();
        
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
        int row = eqType == ItemType.Weapon ? 0 : 1;
        int column = (ID - 1) / 7;
        return _itemCost[row, column];
    }

    public void ClickSound()
    {
        Audio_Efek.PlayOneShot(pressed);
    }
    private bool checkLocked() 
    {
        PlayerData.Instance.LoadDataFromJson();

        int playerRank = PlayerData.Instance.RankPlayer;
        int itemRangeStart = ((playerRank - 1) * 7) + 1;
        int itemRangeEnd = playerRank * 7;
        return itemID < itemRangeStart || itemID > itemRangeEnd;
    }

    private void changeColor() 
    {
        locked = checkLocked();
        Color colorC = gameObject.GetComponent<Image>().color;
        if (locked)
        {
            colorC = new Color(0f, 0f, 0f, 0.85f);
        }
        else
        {
            colorC = new Color(1f, 1f, 1f, 1f);
        }
        gameObject.GetComponent<Image>().color = colorC;
    }

}
