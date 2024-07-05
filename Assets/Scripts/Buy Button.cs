using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class BuyButton : MonoBehaviour
{
    public GameObject message = null;
    public int itemID;
    public bool locked=false;
    private int maxSlot = 12;
    public TextMeshProUGUI playerGoldText;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerRankText;

    private void OnEnable()
    {
        BuyManager.PurchasedItem += buyEquip;
    }

    private void OnDisable()
    {
        BuyManager.PurchasedItem -= buyEquip;
    }
    private void Start()
    {
        updateGoldLabel();
    }
    public void buyEquip()
    {
        if (itemID == 0)
        {
            ShowMessage("No Item Selected...");
            return;
        }

        if (locked)
        {
            ShowMessage("Item Not Unlocked Yet...");
            return;
        }

        PlayerData.Instance.LoadDataFromJson();
        EquipmentObject[] allEquips = PlayerData.Instance.loadAllEquip();

        var equip = getEquip(allEquips, itemID);
        var cost = price(equip.ID, equip.type, PlayerData.Instance.cost);

        if (cost > PlayerData.Instance.GoldPlayer)
        {
            ShowMessage("Insufficient funds...");
            return;
        }

        if (PlayerData.Instance.equipmentItems.Count >= maxSlot)
        {
            ShowMessage("Your Inventory Is Full");
            return;
        }

        PlayerData.Instance.GoldPlayer -= cost;
        EquipmentObject newEquip = Instantiate(equip);
        PlayerData.Instance.equipmentItems.Add(newEquip);
        PlayerData.Instance.SaveDataToJson();
        updateGoldLabel();
        ShowMessage("You've successfully purchased " + equip.eqName);

    }
    private void ShowMessage(string messageText)
    {
        message.SetActive(true);
        message.GetComponentInChildren<TextMeshProUGUI>().text = messageText;
        StartCoroutine(hideMessage());
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
    public void updateGoldLabel() 
    {
        PlayerData.Instance.LoadDataFromJson();        
        playerNameText.text = ("Player Name : " + PlayerData.Instance.NamaPlayer);
        playerRankText.text = ("Rank : " + PlayerData.Instance.GetRankString(PlayerData.Instance.RankPlayer));
        playerGoldText.text = ("Gold : " + PlayerData.Instance.GoldPlayer);
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
