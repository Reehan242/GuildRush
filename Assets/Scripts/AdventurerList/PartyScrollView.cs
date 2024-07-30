using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartyScrollView : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private GameObject prefabListItem;
    private int buttonCount;
    public Transform[] spawnerCube;
    /*private Texture[] allModelTexture;*/
    public GameObject[] advModel;
    public ItemButton[] itemList;

    void Start()
    {
        GameData.Initialize();
        /*allModelTexture = Resources.Load<Texture>("Render Texture/RTadvList" + i);*/
        if (GameData.Player != null)
        {
            buttonCount = GameData.Player.adventurerList.Count;

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

    public void TestCreateItems(int count)
    {
        TraitDataBase[] traitData = GameData.traitData;
        GameData.Initialize();
        spawnerCube = new Transform[count];
        advModel = new GameObject[count];
        itemList = new ItemButton[buttonCount];
        int atk, def, spd;
        for (int i = 0; i < count; i++)
        {
            atk = GameData.Player.adventurerList[i].Atk;
            def = GameData.Player.adventurerList[i].Def;
            spd = GameData.Player.adventurerList[i].Spd;
            if (GameData.Player.adventurerList[i].equipedWeapon != 0)
            {
                PlayerEquipmentData equippedWeapon = GameData.Player.equipments.Find(obj => obj.uniqueID == GameData.Player.adventurerList[i].equipedWeapon);
                atk += equippedWeapon.Atk;
                def += equippedWeapon.Def;
                spd += equippedWeapon.Spd;
                
            }
            if (GameData.Player.adventurerList[i].equipedArmor != 0)
            {
                PlayerEquipmentData equippedArmor = GameData.Player.equipments.Find(obj => obj.uniqueID == GameData.Player.adventurerList[i].equipedArmor);
                atk += equippedArmor.Atk;
                def += equippedArmor.Def;
                spd += equippedArmor.Spd;
            }

            string traitText = string.Empty;
            for (int t = 0; t < GameData.Player.adventurerList[i].TraitId.Count; t++)
            {
                int trait = GameData.Player.adventurerList[i].TraitId[t];
                GameData.GetTraitById(trait);
                traitText += traitData[trait].TraitName;
                if (t < GameData.Player.adventurerList[i].TraitId.Count - 1)
                {
                    traitText += "\n";
                }
            }

            itemList[i] = CreateItem(
            GameData.Player.adventurerList[i].Name,
            GameData.Player.adventurerList[i].Rank,
            GameData.Player.adventurerList[i].Class,
            atk,
            def,
            spd,
            traitText) ;
            itemList[i].adventurerIdx = i;

            spawnerCube[i] = GameObject.Find("SpawningModel" + i).transform;
            if (advModel[i] != null)
            {
                Destroy(advModel[i]);
                advModel[i] = null;
            }
            advModel[i] = ModelSpawner.SpawnModel(GameData.Player.adventurerList[i], spawnerCube[i].transform.position);
            advModel[i].transform.parent = spawnerCube[i];
            advModel[i].transform.rotation = Quaternion.Euler(new Vector3(-90.0f, -90.0f, 0.0f));
            itemList[i].modelValue = Resources.Load<Texture>("Render Texture/RTadvList " + i);
            itemList[i].GetComponentInChildren<PopButton>().SetAdventurerIdx(i);
        }
    }

    //private Sprite CheckRank(Sprite[] cardImg, string strRank)
    //{
    //    int rankIndex = Mathf.Clamp((char.ToUpper(strRank[0]) - 'F'), 0, cardImg.Length - 1);
    //    return cardImg[rankIndex];
    //}

    private ItemButton CreateItem(string strName, string strRank, string strClass, int intAtk, int intDef, int intSpd, string strTrait)
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
        item.ItemTraitValue = strTrait;
        item.ItemAtkValue = intAtk.ToString();
        item.ItemDefValue = intDef.ToString();
        item.ItemSpdValue = intSpd.ToString();
        item.SetItemImage(strRank);

        return item;
    }
}
