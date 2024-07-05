using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private TextMeshProUGUI descText;
    public List<EquipmentObject> items = new List<EquipmentObject>();
    private GameObject[] slots;
    public int itemID;

    public void Start()
    {
        PlayerData.Instance.LoadDataFromJson();
        items = PlayerData.Instance.equipmentItems;
        slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();     
    }
    public void Remove() 
    {
        try
        { 
            DestroyObjectByInstanceID(itemID);
            PlayerData.Instance.LoadDataFromJson();
            PlayerData.Instance.equipmentItems = items;
            PlayerData.Instance.SaveDataToJson();            
            descText.text = ("");
            
            RefreshUI();
        }
        catch
        {
            Debug.Log("No item to discard");
        }
    }

    public void RefreshUI() 
    {
        for (int i = 0;  i < slots.Length; i++)
        { 
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].eqName;
                slots[i].transform.GetComponent<SlotPanel>().itemID = items[i].GetInstanceID();               
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;
                slots[i].transform.GetComponent<SlotPanel>().itemID = 0;               
            }
        }
    }
    public void DestroyObjectByInstanceID(int instanceID)
    {
        EquipmentObject objectToRemove = items.Find(obj => obj.GetInstanceID() == instanceID);

        if (objectToRemove != null)
        {
            items.Remove(objectToRemove);
            DestroyImmediate(objectToRemove,true);
        }
        else
        {
            Debug.LogWarning("Objek dengan Instance ID " + instanceID + " tidak ditemukan.");
        }
    }
}
