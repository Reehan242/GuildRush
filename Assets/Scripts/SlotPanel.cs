using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class SlotPanel : MonoBehaviour
{
    public int itemID;
    public AudioSource Audio_Efek;
    public AudioClip pressed;
    public List<EquipmentObject> items = new List<EquipmentObject>();
    [SerializeField] private GameObject inventory;
    [SerializeField] private TextMeshProUGUI descText;
    public void changeInventoryID() 
    {
        try
        {
            PlayerData.Instance.LoadDataFromJson();
            items = PlayerData.Instance.equipmentItems;
            EquipmentObject equip = items.Find(obj => obj.GetInstanceID() == itemID);
            inventory.GetComponent<InventoryManager>().itemID = itemID;
            descText.text = ("***" + equip.eqName + "***" + "\nLevel = "+equip.level+"\nHP Bonus = " + equip.hpBonus + "\nATK Bonus = " + equip.atkBonus
                         + "\nDEF Bonus = " + equip.defBonus + "\nSPD Bonus = " + equip.spdBonus);
        }
        catch 
        {
            descText.text = ("");
            Debug.Log("Nothing Selected");
        }
    }
    public void ClickSound()
    {
        Audio_Efek.PlayOneShot(pressed);
    }

}
