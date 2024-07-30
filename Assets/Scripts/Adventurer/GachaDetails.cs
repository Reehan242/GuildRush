using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GachaDetails : MonoBehaviour
{
    public AdventurerData adventurerData;
    public PlayerData playerData;


    public TMP_Text NameText;
    public TMP_Text AtkText;
    public TMP_Text SpdText;
    public TMP_Text DefText;
    public TMP_Text ClassText;
    /* public TMP_Text GenderText;*/


    /*    public PlayerData dataPlayer;

       public PlayerData LoadDataPlayer()
        {
            GameData.Initialize();
            PlayerData dataPlayer = GameData.Player;
            return dataPlayer;
        }

        public void Start()
        {
            dataPlayer = LoadDataPlayer();
        }
    */

/*    public void adventurerPopUp(AdventurerData adventurerData)
    {
        if (adventurerData != null)
        {
            Debug.Log(" not null");
            string nama = adventurerData.Name;
            string Class = adventurerData.Class;
            int atk = adventurerData.Atk;
            int speed = adventurerData.Spd;
            int def = adventurerData.Def;

            NameText.text = "Nama: " + nama;
            ClassText.text = "Class: " + Class;
            AtkText.text = "ATK: " + atk;
            SpdText.text = "Speed: " + speed;
            DefText.text = "DEF: " + def;
        }
        else
        {
            Debug.Log("null");
        }
    }*/
}
