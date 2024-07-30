using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScrollViewSample : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private GameObject prefabListItem;
    private int buttonCount;
    public Transform[] spawnerCube;
    public GameObject[] advModel;
    public ItemButton[] itemList;

    void Start()
    {
        PlayerData dataPlayer = loadDataPlayer();
        if (dataPlayer != null)
        {
            buttonCount = dataPlayer.adventurerList.Count;
        }
        if (buttonCount > 0)
        {
            TestCreateItems(buttonCount);
            
            //updateAllButtonNavigationalReferences();
        }

    }

    //private void updateAllButtonNavigationalReferences()
    //{
    //    ItemButton[] children = content.transform.GetComponentsInChildren<ItemButton>();
    //    if (children.Length < 2) return;

    //    for (int i = 0; i < children.Length; i++)
    //    {
    //        ItemButton item = children[i];
    //        Navigation navigation = item.gameObject.GetComponent<Button>().navigation;
    //        navigation.selectOnLeft = GetNavigationLeft(i, children.Length);
    //        navigation.selectOnRight = GetNavigationRight(i, children.Length);

    //        item.gameObject.GetComponent<Button>().navigation = navigation;
    //    }
    //}

    private Selectable GetNavigationRight(int indexCurrent, int totalEntries)
    {
        ItemButton item;
        if (indexCurrent == totalEntries - 1)
            item = content.transform.GetChild(0).GetComponent<ItemButton>();
        else
            item = content.transform.GetChild(indexCurrent + 1).GetComponent<ItemButton>();
        return item.GetComponent<Selectable>();
    }

    private Selectable GetNavigationLeft(int indexCurrent, int totalEntries)
    {
        ItemButton item;
        if (indexCurrent == 0)
            item = content.transform.GetChild(totalEntries - 1).GetComponent<ItemButton>();
        else
            item = content.transform.GetChild(indexCurrent - 1).GetComponent<ItemButton>();
        return item.GetComponent<Selectable>();
    }

    private void TestCreateItems(int count)
    {
        
        PlayerData dataPlayer = loadDataPlayer();
        spawnerCube = new Transform[count];
        advModel = new GameObject[count];
        itemList = new ItemButton[buttonCount];
        int atk, def, spd;
        /*for (int i = 0; i < count; i++)
        {
            
            ItemButton item = CreateItem(
                dataPlayer.adventurerList[i].Name,
                dataPlayer.adventurerList[i].Rank,
                dataPlayer.adventurerList[i].Class,
                dataPlayer.adventurerList[i].Atk,
                dataPlayer.adventurerList[i].Def,
                dataPlayer.adventurerList[i].Spd
                );
            item.adventurerIdx = i;
        }*/
        for (int i = 0; i < count; i++)
        {
            atk = dataPlayer.adventurerList[i].Atk;
            def = dataPlayer.adventurerList[i].Def;
            spd = dataPlayer.adventurerList[i].Spd;
            if (dataPlayer.adventurerList[i].equipedWeapon != 0)
            {
                PlayerEquipmentData equippedWeapon = dataPlayer.equipments.Find(obj => obj.uniqueID == dataPlayer.adventurerList[i].equipedWeapon);
                atk += equippedWeapon.Atk;
                def += equippedWeapon.Def;
                spd += equippedWeapon.Spd;

            }
            if (dataPlayer.adventurerList[i].equipedArmor != 0)
            {
                PlayerEquipmentData equippedArmor = dataPlayer.equipments.Find(obj => obj.uniqueID == dataPlayer.adventurerList[i].equipedArmor);
                atk += equippedArmor.Atk;
                def += equippedArmor.Def;
                spd += equippedArmor.Spd;
            }
            itemList[i] = CreateItem(
            dataPlayer.adventurerList[i].Name,
            dataPlayer.adventurerList[i].Rank,
            dataPlayer.adventurerList[i].Class,
            atk,
            def,
            spd);
            itemList[i].adventurerIdx = i;

            spawnerCube[i] = GameObject.Find("SpawningModel" + i).transform;
            if (advModel[i] != null)
            {
                Destroy(advModel[i]);
                advModel[i] = null;
            }
            advModel[i] = ModelSpawner.SpawnModel(dataPlayer.adventurerList[i], spawnerCube[i].transform.position);
            advModel[i].transform.parent = spawnerCube[i];
            advModel[i].transform.rotation = Quaternion.Euler(new Vector3(-90.0f, -90.0f, 0.0f));
            itemList[i].modelValue = Resources.Load<Texture>("Render Texture/RTadvList " + i);
            
        }
    }

    //private Sprite CheckRank(Sprite[] cardImg, string strRank)
    //{
    //    int rankIndex = Mathf.Clamp((char.ToUpper(strRank[0]) - 'F'), 0, cardImg.Length - 1);
    //    return cardImg[rankIndex];
    //}

    private ItemButton CreateItem(string strName, string strRank, string strClass, int intAtk, int intDef, int intSpd)
    {
        GameObject gObj = Instantiate(prefabListItem, Vector3.zero, Quaternion.identity);
        gObj.transform.SetParent(content.transform);
        gObj.transform.localScale = new Vector3(2f, 2f, 2f);
        gObj.transform.localPosition = new Vector3();
        gObj.transform.localRotation = Quaternion.Euler(new Vector3());
        gObj.name = strName;

        ItemButton item = gObj.GetComponent<ItemButton>();
        item.ItemNameValue = strName;
        item.ItemRankValue = strRank;
        item.ItemClassValue = strClass;
        item.ItemAtkValue = intAtk.ToString();
        item.ItemDefValue = intDef.ToString();
        item.ItemSpdValue = intSpd.ToString();
        item.SetItemImage(strRank);
    
        return item;
        
    }

    public PlayerData loadDataPlayer()
    {
        GameData.Initialize();
        PlayerData dataPlayer = GameData.Player;

        return dataPlayer;
    }
}
