using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TestingEquip;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    /*public List<int> uniqueID = new List<int>();*/
    public List<EquipmentObject> items = new List<EquipmentObject>();
    private List<Sprite> equipIcon = new List<Sprite>();
    public GameObject[] testing;
    public GameObject message;
    private GameObject[] slots;
    public GameObject harmor;
    public GameObject larmor;
    public int itemID;
    public int page;

    public void Start()
    {
        EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");
        page = 1;
        PlayerData dataPlayer = loadDataPlayer();
        /*uniqueID = dataPlayer.uniqueID;*/
        
        for (int j = 0; j < dataPlayer.uniqueID.Count; j++)
        {
            EquipmentObject Equip = getEquip(allEquips, dataPlayer.equipID[j]); ;
            EquipmentObject newEquip = Instantiate(Equip);
            newEquip.uniqueID = dataPlayer.uniqueID[j];
            items.Add(newEquip);
        }
        
        
        slots = new GameObject[slotHolder.transform.childCount];
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        changePage();
        RefreshUI();
        
    }
    public List<EquipmentObject> getAllEquip()
    {
        EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");
        List<EquipmentObject> allEquips_ = new List<EquipmentObject>();
        allEquips_.AddRange(allEquips);
        return allEquips_;
    }
    public void nextPage()
    {
        if (page < 5)
        {
            page += 1;
            changePage();
        }
        
    }
    public void previousPage()
    {
        if(page > 1)
        {
            page -= 1;
            changePage();
        }
    }
    public void changePage()
    {
        TextMeshProUGUI pageNumber = GameObject.Find("page_number").GetComponent<TextMeshProUGUI>();
        switch (page)
        {
            case 1:
                for(int i  = 0; i < slots.Length; i++)
                {
                    if(i > 11)
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.zero;
                    }
                    else
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.one;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < slots.Length; i++)
                {
                    if (i < 12 || i > 23)
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.zero;
                    }
                    else
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.one;
                    }
                }
                break;
            case 3:
                for (int i = 0; i < slots.Length; i++)
                {
                    if (i < 24 || i > 35)
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.zero;
                    }
                    else
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.one;
                    }
                }
                break;
            case 4:
                for (int i = 0; i < slots.Length; i++)
                {
                    if (i < 36 || i > 47)
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.zero;
                    }
                    else
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.one;
                    }
                }
                break;
            case 5:
                for (int i = 0; i < slots.Length; i++)
                {
                    if (i < 48)
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.zero;
                    }
                    else
                    {
                        slots[i].GetComponent<Transform>().localScale = Vector3.one;
                    }
                }
                break;
        }
        pageNumber.text = (page + " / 5");
    }
    public void equipEquipment()
    {
        try
        {
            EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");
            GameObject adventurer = GameObject.Find("PopUp");
            PlayerData dataPlayer = loadDataPlayer();
            if (dataPlayer.adventurerList.Count != 0)
            {

                List<AdventurerData> allAdventurer = dataPlayer.adventurerList;
                AdventurerData selectedAdventurer;
                if (allAdventurer != null)
                {
                    int advIndex = adventurer.GetComponent<Adventurerdetails>().GetSelectedAdventurerIdx();
                    selectedAdventurer = allAdventurer[advIndex];
                    PlayerEquipmentData itemToEquip = dataPlayer.equipments.Find(obj => obj.uniqueID == itemID);
                    EquipmentObject itemToEquip_ = getEquip(allEquips, itemToEquip.equipID);

                    if (itemToEquip_.type == ItemType.Weapon && itemToEquip.equipped == false)
                    {
                        if (selectedAdventurer.equipedWeapon == 0)
                        {
                            if (check_class(dataPlayer, advIndex, itemToEquip_) == true)
                            {
                                selectedAdventurer.equipedWeapon = itemToEquip.uniqueID;
                                itemToEquip.equipped = true;
                                message.SetActive(true);
                                message.GetComponentInChildren<TextMeshProUGUI>().text = (selectedAdventurer.Name + " is equipped with Level " + itemToEquip.level + " " + itemToEquip_.eqName);
                                StartCoroutine(hideMessage());
                                Debug.Log(selectedAdventurer.Name + " is equipped with Level " + itemToEquip.level + " " + itemToEquip_.eqName);
                                PlayerData.SaveDataToJson(dataPlayer);
                                
                            }
                            else
                            {
                                selectedAdventurer.equipedWeapon = 0;
                                message.SetActive(true);
                                message.GetComponentInChildren<TextMeshProUGUI>().text = ("This adventurer cannot use this type of weapon");
                                StartCoroutine(hideMessage());
                                Debug.Log("This adventurer cannot use this type of weapon");
                            }
                        }
                        else
                        {
                            message.SetActive(true);
                            message.GetComponentInChildren<TextMeshProUGUI>().text = ("This adventurer is already equipped with weapon");
                            StartCoroutine(hideMessage());
                            Debug.Log("This adventurer is already equipped with weapon");
                        }

                    }
                    else if (itemToEquip_.type == ItemType.Armor && itemToEquip.equipped == false)
                    {
                        if (selectedAdventurer.equipedArmor == 0)
                        {
                            selectedAdventurer.equipedArmor = itemToEquip.uniqueID;
                            itemToEquip.equipped = true;
                            message.SetActive(true);
                            message.GetComponentInChildren<TextMeshProUGUI>().text = (selectedAdventurer.Name + " is equipped with " + itemToEquip_.eqName);
                            StartCoroutine(hideMessage());
                            Debug.Log(selectedAdventurer.Name + " is equipped with " + itemToEquip_.eqName);
                            PlayerData.SaveDataToJson(dataPlayer);
                        }
                        else
                        {
                            message.SetActive(true);
                            message.GetComponentInChildren<TextMeshProUGUI>().text = ("This adventurer is already equipped with armor");
                            StartCoroutine(hideMessage());
                            Debug.Log("This adventurer is already equipped with armor");
                        }
                    }
                    else
                    {
                        message.SetActive(true);
                        message.GetComponentInChildren<TextMeshProUGUI>().text = ("This Equipment is already equipped on an adventurer");
                        StartCoroutine(hideMessage());
                        Debug.Log("This Equipment is already equipped on an adventurer");
                    }
                    PartyScrollView partyScrollView = GameObject.Find("ScrollViewSample").GetComponent<PartyScrollView>();
                    partyScrollView.itemList[advIndex].ItemAtkValue = (selectedAdventurer.Atk+itemToEquip.Atk).ToString();
                    partyScrollView.itemList[advIndex].ItemDefValue = (selectedAdventurer.Def + itemToEquip.Def).ToString();
                    partyScrollView.itemList[advIndex].ItemSpdValue = (selectedAdventurer.Spd + itemToEquip.Spd).ToString();
                    if (partyScrollView.advModel[advIndex] != null)
                    {
                        Destroy(partyScrollView.advModel[advIndex]);
                        partyScrollView.advModel[advIndex] = null;
                    }
                    partyScrollView.advModel[advIndex] = ModelSpawner.SpawnModel(dataPlayer.adventurerList[advIndex], partyScrollView.spawnerCube[advIndex].transform.position);
                    partyScrollView.advModel[advIndex].transform.parent = partyScrollView.spawnerCube[advIndex].transform;
                    partyScrollView.advModel[advIndex].transform.rotation = Quaternion.Euler(new Vector3(-90.0f, -90.0f, 0.0f));
                    adventurer.GetComponent<Adventurerdetails>().UpdateDetailsBasedOnIndex(advIndex);
                }
            }
            else
            {
                Debug.Log("No adventurer selected...");
            }
        }
        catch
        {
            Debug.Log("No Item Selected...");
        }
        

    }
    public void unequip()
    {
        try
        {
            PlayerData dataPlayer = loadDataPlayer();
            PlayerEquipmentData itemToUnequip = dataPlayer.equipments.Find(obj => obj.uniqueID == itemID);
            GameObject adventurerDetails = GameObject.Find("PopUp");
            int advIndex = adventurerDetails.GetComponent<Adventurerdetails>().GetSelectedAdventurerIdx();
            if (itemToUnequip.equipped == true)
            {
                foreach (var adventurer in dataPlayer.adventurerList)
                {
                    if (adventurer.equipedWeapon == itemToUnequip.uniqueID)
                    {
                        adventurer.equipedWeapon = 0;
                        itemToUnequip.equipped = false;
                        message.SetActive(true);
                        message.GetComponentInChildren<TextMeshProUGUI>().text = ("Item has been unequipped");
                        StartCoroutine(hideMessage());
                        Debug.Log("Item has been unequipped");   
                        PlayerData.SaveDataToJson(dataPlayer);
                        
                    }
                    else if (adventurer.equipedArmor == itemToUnequip.uniqueID)
                    {
                        adventurer.equipedArmor = 0;
                        itemToUnequip.equipped = false;
                        message.SetActive(true);
                        message.GetComponentInChildren<TextMeshProUGUI>().text = ("Item has been unequipped");
                        StartCoroutine(hideMessage());
                        Debug.Log("Item has been unequipped");
                        PlayerData.SaveDataToJson(dataPlayer);
                    }
                }
                PartyScrollView partyScrollView = GameObject.Find("ScrollViewSample").GetComponent<PartyScrollView>();
                partyScrollView.itemList[advIndex].ItemAtkValue = dataPlayer.adventurerList[advIndex].Atk.ToString();
                partyScrollView.itemList[advIndex].ItemDefValue = dataPlayer.adventurerList[advIndex].Def.ToString();
                partyScrollView.itemList[advIndex].ItemSpdValue = dataPlayer.adventurerList[advIndex].Spd.ToString();
                if (partyScrollView.advModel[advIndex] != null)
                {
                    Destroy(partyScrollView.advModel[advIndex]);
                    partyScrollView.advModel[advIndex] = null;
                }
                partyScrollView.advModel[advIndex] = ModelSpawner.SpawnModel(dataPlayer.adventurerList[advIndex], partyScrollView.spawnerCube[advIndex].transform.position);
                partyScrollView.advModel[advIndex].transform.parent = partyScrollView.spawnerCube[advIndex].transform;
                partyScrollView.advModel[advIndex].transform.rotation = Quaternion.Euler(new Vector3(-90.0f, -90.0f, 0.0f));
                adventurerDetails.GetComponent<Adventurerdetails>().UpdateDetailsBasedOnIndex(advIndex);
            }
        }
        catch
        {
            Debug.Log("No item selected...");
        }
        
    }
    public void Add(int item) 
    {
        EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");

        PlayerData dataPlayer = loadDataPlayer();
        for (int j = 0; j < dataPlayer.uniqueID.Count; j++)
        {
            EquipmentObject Equip = getEquip(allEquips, dataPlayer.equipID[j]); ;
            EquipmentObject newEquip = Instantiate(Equip);
            newEquip.uniqueID = dataPlayer.uniqueID[j];
            items.Add(newEquip);
        }
        RefreshUI();
    }
    public PlayerData loadDataPlayer() 
    {
        GameData.Initialize();
        PlayerData dataPlayer = GameData.Player;
        
        return dataPlayer;
    }
    public void Remove() 
    {
        PlayerData dataPlayer = loadDataPlayer();
        try
        {
            AdventurerData advWithEquip;
            EquipmentObject itemToRemove = items.Find(itm => itm.uniqueID == itemID);

            PlayerEquipmentData dataToRemove = dataPlayer.equipments.Find(itm=> itm.uniqueID == itemID);
            message.SetActive(true);
            message.GetComponentInChildren<TextMeshProUGUI>().text = ("Item has been discarded");
            StartCoroutine(hideMessage());
            if (itemToRemove.type == ItemType.Weapon && dataToRemove.equipped == true)
            {
                advWithEquip = dataPlayer.adventurerList.Find(obj => obj.equipedWeapon == itemID);
                advWithEquip.equipedWeapon = 0;
            }
            else if (itemToRemove.type == ItemType.Armor && dataToRemove.equipped == true)
            {
                advWithEquip = dataPlayer.adventurerList.Find(obj => obj.equipedArmor == itemID);
                advWithEquip.equipedArmor = 0;
            }
            DestroyObjectByInstanceID(itemToRemove.uniqueID);
            dataPlayer.equipments.Remove(dataToRemove);
            for (int j = 0; j < dataPlayer.uniqueID.Count; j++)
            {
               if (dataPlayer.uniqueID[j] == itemID)
                {
                    dataPlayer.uniqueID.RemoveAt(j);
                    dataPlayer.equipID.RemoveAt(j);
                }
            }
            PlayerData.SaveDataToJson(dataPlayer);
            
            GameObject description = GameObject.Find("DescText");
            harmor.SetActive(false);
            larmor.SetActive(false);
            TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
            text.text = ("");
            GameObject cubeTest = GameObject.Find("PlaceCube");
            spawnAssets displayAsset = cubeTest.GetComponent<spawnAssets>();
            displayAsset.destroyAsset();
            
            RefreshUI();

        }
        catch
        {
            Debug.Log("No item to discard");
        }
    }

    public void increaseStatEquip()
    {
        try
        {
            PlayerData dataPlayer = loadDataPlayer();
            EquipmentObject itemToUpgraded = items.Find(itm => itm.uniqueID == itemID);
            PlayerEquipmentData equiData = dataPlayer.equipments.Find(itm => itm.uniqueID == itemID);

            itemToUpgraded.level = equiData.level;
            itemToUpgraded.hpBonus = equiData.hp;
            itemToUpgraded.atkBonus = equiData.Atk;
            itemToUpgraded.defBonus = equiData.Def;
            itemToUpgraded.spdBonus = equiData.Spd;

            var cost = price(itemToUpgraded.ID, itemToUpgraded.type, EquipmentData.cost);
            var upgradePrice = (int)(itemToUpgraded.level * 0.5 * cost);
            if (itemToUpgraded.type == ItemType.Weapon)
            {
                if (equiData.level < 20)
                {
                    if (dataPlayer.GoldPlayer >= upgradePrice)
                    {
                        dataPlayer.GoldPlayer -= upgradePrice;

                        itemToUpgraded.level += 1;
                        itemToUpgraded.atkBonus += GameData.statGrowth[0, itemToUpgraded.ID - 1];
                        itemToUpgraded.defBonus += GameData.statGrowth[1, itemToUpgraded.ID - 1];
                        itemToUpgraded.spdBonus += GameData.statGrowth[2, itemToUpgraded.ID - 1];


                        equiData.level = itemToUpgraded.level;
                        equiData.hp = itemToUpgraded.hpBonus;
                        equiData.Atk = itemToUpgraded.atkBonus;
                        equiData.Def = itemToUpgraded.defBonus;
                        equiData.Spd = itemToUpgraded.spdBonus;
                        PlayerData.SaveDataToJson(dataPlayer);
                        message.SetActive(true);
                        message.GetComponentInChildren<TextMeshProUGUI>().text = ("Item has been upgraded");
                        StartCoroutine(hideMessage());
                        Debug.Log("Upgrade Succesful");
                        GameObject description = GameObject.Find("DescText");
                        GameObject description2 = GameObject.Find("DescText 2");
                        if (itemToUpgraded.type == ItemType.Weapon)
                        {
                            TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
                            TextMeshProUGUI text2 = description2.GetComponent<TextMeshProUGUI>();
                            text.text = ("***" + itemToUpgraded.eqName + "***" + "\n\nLevel : " + itemToUpgraded.level + "\nHP Bonus : " + itemToUpgraded.hpBonus + "\nATK Bonus : " + itemToUpgraded.atkBonus
                                         + "\nDEF Bonus : " + itemToUpgraded.defBonus + "\nSPD Bonus : " + itemToUpgraded.spdBonus);

                            text2.text = ("Next Level\n\nLevel : " + (itemToUpgraded.level + 1) + "\nHP Bonus : " + (itemToUpgraded.hpBonus) + "\nATK Bonus : " + (itemToUpgraded.atkBonus + GameData.statGrowth[0, itemToUpgraded.ID - 1])
                                         + " (+" + GameData.statGrowth[0, itemToUpgraded.ID - 1] + ")\nDEF Bonus : " + (itemToUpgraded.defBonus + GameData.statGrowth[1, itemToUpgraded.ID - 1]) + " (+" + GameData.statGrowth[1, itemToUpgraded.ID - 1] + ")\nSPD Bonus : "
                                         + (itemToUpgraded.spdBonus + GameData.statGrowth[2, itemToUpgraded.ID - 1]) + " (+" + GameData.statGrowth[2, itemToUpgraded.ID - 1] + ")\n\nCost : " + (itemToUpgraded.level * 0.5 * cost));
                        }
                        else
                        {
                            TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
                            TextMeshProUGUI text2 = description2.GetComponent<TextMeshProUGUI>();
                            text.text = ("This Item Is Not Available For Upgrade");
                            text2.text = ("");
                        }

                    }
                    else
                    {
                        message.SetActive(true);
                        message.GetComponentInChildren<TextMeshProUGUI>().text = ("Insufficient funds");
                        StartCoroutine(hideMessage());
                        Debug.Log("Insufficient funds");
                    }
                }
                else
                {
                    GameObject description = GameObject.Find("DescText");
                    GameObject description2 = GameObject.Find("DescText 2");
                    if (itemToUpgraded.type == ItemType.Weapon)
                    {
                        TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
                        TextMeshProUGUI text2 = description2.GetComponent<TextMeshProUGUI>();
                        text.text = ("***" + itemToUpgraded.eqName + "***" + "\n\nLevel : " + itemToUpgraded.level + "\nHP Bonus : " + itemToUpgraded.hpBonus + "\nATK Bonus : " + itemToUpgraded.atkBonus
                                     + "\nDEF Bonus : " + itemToUpgraded.defBonus + "\nSPD Bonus : " + itemToUpgraded.spdBonus);

                        text2.text = ("Max Level");
                        message.SetActive(true);
                        message.GetComponentInChildren<TextMeshProUGUI>().text = ("This item has reached max level");
                        StartCoroutine(hideMessage());
                    }
                    else
                    {
                        TextMeshProUGUI text = description.GetComponent<TextMeshProUGUI>();
                        TextMeshProUGUI text2 = description2.GetComponent<TextMeshProUGUI>();
                        text.text = ("This Item Is Not Available For Upgrade");
                        text2.text = ("");
                    }
                }
                
            }
            else
            {
                message.SetActive(true);
                message.GetComponentInChildren<TextMeshProUGUI>().text = ("This item cannot be upgraded");
                StartCoroutine(hideMessage());
                Debug.Log("This item cannot be upgraded");
            }
            RefreshUI();
        }
        catch
        {
            message.SetActive(true);
            message.GetComponentInChildren<TextMeshProUGUI>().text = ("Nothing To Upgrade..");
            StartCoroutine(hideMessage());
        }
        
        
    }

    public void RefreshUI() 
    {
        Sprite[] allEquipIcon = Resources.LoadAll<Sprite>("Assets/Equipment Icon");
        equipIcon.AddRange(allEquipIcon);
        for (int i = 0;  i < slots.Length; i++)
        {
            
            try
            {
                PlayerData dataPlayer = loadDataPlayer();
                List<PlayerEquipmentData> equiData = dataPlayer.equipments;
                
                items[i].level = equiData[i].level;
                var name = items[i].eqName + " (+" + (items[i].level - 1)+")";

                /*testing[i] = Instantiate(items[i].prefab, slots[i].transform);
                testing[i].transform.position = new Vector3(slots[i].transform.position.x - 0.2f, slots[i].transform.position.y - 0.5f, slots[i].transform.position.z - 0.02f);
                testing[i].transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
                testing[i].transform.rotation = Quaternion.Euler(new Vector3(-120.0f, -90.0f, 0.0f));
                testing[i].layer = 5;*/

                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                
                if (items[i].equipmentType == eqType.heavyArmor)
                {
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(-1.0f, -1.0f);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(1.0f, 1.0f);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = equipIcon.Find(obj => obj.name == "sample_heavyarmor");
                }
                else if (items[i].equipmentType == eqType.lightArmor)
                {
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(-1.0f, -1.0f);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(1.0f, 1.0f);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = equipIcon.Find(obj => obj.name == "sample_lightarmor");
                }
                else
                {
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(30.0f, 10.0f);
                    slots[i].transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(-30.0f, -10.0f);
                    slots[i].transform.GetChild(0).GetComponent<Image>().sprite = equipIcon.Find(obj => obj.name == items[i].eqName);
                }
                
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
                if (items[i].level > 1)
                {
                    slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = name;
                }
                else
                {
                    slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].eqName;
                }
                
                slots[i].transform.GetComponent<SlotPanel>().itemID = items[i].uniqueID;
                
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(5.0f, 5.0f);
                slots[i].transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(5.0f, 5.0f);
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;
                slots[i].transform.GetComponent<SlotPanel>().itemID = 0;
                
               





            }
        }
    }
    public void DestroyObjectByInstanceID(int instanceID)
    {
        EquipmentObject objectToRemove = items.Find(obj => obj.uniqueID == instanceID);
        

        if (objectToRemove != null)
        {
            items.Remove(objectToRemove);
            DestroyImmediate(objectToRemove, true); // Menghapus objek dari hierarki permainan
        }
        else
        {
            Debug.LogWarning("Objek dengan ID " + instanceID + " tidak ditemukan.");
        }
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
    public bool check_class(PlayerData dataPlayer, int indexAdv,EquipmentObject itemToCheck)
    {
        bool paired_type = false;
        switch (dataPlayer.adventurerList[indexAdv].Class)
        {
            case "Warrior":
                if (itemToCheck.equipmentType == eqType.sword)
                {
                    paired_type = true;
                }
                else
                {
                    paired_type = false;
                }
                break;
            case "Archer":
                if (itemToCheck.equipmentType == eqType.bow)
                {
                    paired_type = true;
                }
                else
                {
                    paired_type = false;
                }
                break;
            case "Knight":
                if (itemToCheck.equipmentType == eqType.shield)
                {
                    paired_type = true;
                }
                else
                {
                    paired_type = false;
                }
                break;
            case "Mage":
                if (itemToCheck.equipmentType == eqType.rod)
                {
                    paired_type = true;
                }
                else
                {
                    paired_type = false;
                }
                break;
            case "Priest":
                if (itemToCheck.equipmentType == eqType.book)
                {
                    paired_type = true;
                }
                else
                {
                    paired_type = false;
                }
                break;

        }
        return paired_type;
    }
    private IEnumerator hideMessage()
    {
        yield return new WaitForSeconds(3);
        message.SetActive(false);
    }
    public void Awake()
    {
        if (message != null)
        {
            message.SetActive(false);
        }
        
    }
}
