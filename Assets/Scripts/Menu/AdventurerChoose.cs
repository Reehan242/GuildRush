using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class AdventurerChoose : MonoBehaviour
{

    public GameObject MunculPilihAdventurer;
    public GameObject MunculMenu;
    public RawImage display1;
    public RawImage display2;
    public RawImage display3;
    public TextMeshProUGUI adv1;
    public TextMeshProUGUI adv2;
    public TextMeshProUGUI adv3;
    public int advID;

    public void Start()
    {
        ClosePanel();
        
        UpdateModel();
    }
    public void UpdateModel()
    {
        GameData.Initialize();
        PlayerData dataPlayer = PlayerData.LoadDataFromJson();
        

        display1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Render Texture/RTadvList " + dataPlayer.Party[0]);
        adv1.GetComponent<TextMeshProUGUI>().text = (dataPlayer.adventurerList[dataPlayer.Party[0]].Name + "\n" + dataPlayer.adventurerList[dataPlayer.Party[0]].Rank + "-Rank " + dataPlayer.adventurerList[dataPlayer.Party[0]].Class);
        
         
        display2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Render Texture/RTadvList " + dataPlayer.Party[1]);
        adv2.GetComponent<TextMeshProUGUI>().text = (dataPlayer.adventurerList[dataPlayer.Party[1]].Name + "\n" + dataPlayer.adventurerList[dataPlayer.Party[1]].Rank + "-Rank " + dataPlayer.adventurerList[dataPlayer.Party[1]].Class);
        
        
        display3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Render Texture/RTadvList " + dataPlayer.Party[2]);
        adv3.GetComponent<TextMeshProUGUI>().text = (dataPlayer.adventurerList[dataPlayer.Party[2]].Name + "\n" + dataPlayer.adventurerList[dataPlayer.Party[2]].Rank + "-Rank " + dataPlayer.adventurerList[dataPlayer.Party[2]].Class);
        


        
    }
    public void ClosePanel()
    {
        MunculPilihAdventurer.transform.localScale = Vector3.zero;
        MunculMenu.transform.localScale = Vector3.one;
        UpdateModel();
    }

    public void PilihAdventurer(int ID)
    {
        MunculPilihAdventurer.transform.localScale = Vector3.one;
        advID = ID;
        MunculMenu.transform.localScale = Vector3.zero;
    }
    public void Awake()
    {
        GameData.Initialize();
        PlayerData dataPlayer = PlayerData.LoadDataFromJson();
        dataPlayer.Party = new int[3];
        dataPlayer.Party[0] = 0;
        dataPlayer.Party[1] = 1;
        dataPlayer.Party[2] = 2;
        PlayerData.SaveDataToJson(dataPlayer);
    }
}
