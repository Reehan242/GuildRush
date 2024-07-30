using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AdventurerSelect : MonoBehaviour
{
    public int changeAdv;
    GameObject adventurerModel;
    // Start is called before the first frame update
    void Start()
    {
        changeAdv = 0;
        adventurerModel = null;
    }
    public void changeAdventurerID()
    {
        PlayerData dataPlayer = loadDataPlayer();
        if (dataPlayer.adventurerList.Count != 0)
        {
            if (changeAdv < (dataPlayer.adventurerList.Count - 1))
            {
                changeAdv += 1;
            }
            else
            {
                changeAdv = 0;
            }
        }
        else
        {
            Debug.Log("No adventurer...");
        }

    }
    public void display_onclick()
    {
        /*try
        {*/
        PlayerData dataPlayer = loadDataPlayer();
        if (dataPlayer.adventurerList.Count != 0)
        {
            
            List<AdventurerData> allAdventurer = dataPlayer.adventurerList;

            if (allAdventurer != null)
            {
                displayAdventurer(changeAdv, allAdventurer, dataPlayer);
            }
        }
        else
        {
            Debug.Log("No adventurer...");
        }
            

        /*}
        catch
        {*/
        /*Debug.Log("No Adventurer");*/
        /*}*/
    }
    public void displayAdventurer(int indexAdventurer, List<AdventurerData> allAdventurer,PlayerData dataPlayer)
    {
        AdventurerData adventureToDisplay;
        adventureToDisplay = allAdventurer[indexAdventurer];
        PlayerEquipmentData isWeapon = dataPlayer.equipments.Find(obj => obj.uniqueID == adventureToDisplay.equipedWeapon);
        if(isWeapon == null && adventureToDisplay.equipedWeapon != 0)
        {
            adventureToDisplay.equipedWeapon = 0;
            PlayerData.SaveDataToJson(dataPlayer);
        }    
        PlayerEquipmentData isArmor = dataPlayer.equipments.Find(obj => obj.uniqueID == adventureToDisplay.equipedArmor);
        if(isArmor == null && adventureToDisplay.equipedArmor != 0)
        {
            adventureToDisplay.equipedArmor = 0;
            PlayerData.SaveDataToJson(dataPlayer);
        }

        if (adventureToDisplay.equipedWeapon == 0 && adventureToDisplay.equipedArmor == 0)
        {
            Debug.Log("Adventurer name : " + adventureToDisplay.Name + "\nClass : " + adventureToDisplay.Class + "\nHp : " + 100 + "\nAtk : " + adventureToDisplay.Atk + "\nDef : " + adventureToDisplay.Def
            + "\nSpd : " + adventureToDisplay.Spd);
        }
        else if (adventureToDisplay.equipedWeapon != 0 && adventureToDisplay.equipedArmor == 0)
        {
            PlayerEquipmentData equipedWeapon = dataPlayer.equipments.Find(obj => obj.uniqueID == adventureToDisplay.equipedWeapon);
            Debug.Log("Adventurer name : " + adventureToDisplay.Name + "\nClass : " + adventureToDisplay.Class + "\nHp : " + (100 + equipedWeapon.hp) + "\nAtk : "
                + (adventureToDisplay.Atk + equipedWeapon.Atk) + "\nDef : " + (adventureToDisplay.Def + equipedWeapon.Atk)
                + "\nSpd : " + (adventureToDisplay.Spd + equipedWeapon.Spd));

        }
        else if (adventureToDisplay.equipedWeapon == 0 && adventureToDisplay.equipedArmor != 0)
        {     
            PlayerEquipmentData equipedArmor = dataPlayer.equipments.Find(obj => obj.uniqueID == adventureToDisplay.equipedArmor);
            Debug.Log("Adventurer name : " + adventureToDisplay.Name + "\nClass : " + adventureToDisplay.Class + "\nHp : " + (100 + equipedArmor.hp) + "\nAtk : "
                + (adventureToDisplay.Atk + equipedArmor.Atk) + "\nDef : " + (adventureToDisplay.Def + equipedArmor.Def)
                + "\nSpd : " + (adventureToDisplay.Spd + equipedArmor.Spd));
       
        }
        else if (adventureToDisplay.equipedWeapon != 0 && adventureToDisplay.equipedArmor != 0)
        {
            PlayerEquipmentData equipedArmor = dataPlayer.equipments.Find(obj => obj.uniqueID == adventureToDisplay.equipedArmor);
            PlayerEquipmentData equipedWeapon = dataPlayer.equipments.Find(obj => obj.uniqueID == adventureToDisplay.equipedWeapon);
            Debug.Log("Adventurer name : " + adventureToDisplay.Name + "\nClass : " + adventureToDisplay.Class
            + "\nHp : " + (100 + equipedWeapon.hp + equipedArmor.hp)
            + "\nAtk : " + (adventureToDisplay.Atk + equipedWeapon.Atk + equipedArmor.Atk)
            + "\nDef : " + (adventureToDisplay.Def + equipedWeapon.Def + equipedArmor.Def)
            + "\nSpd : " + (adventureToDisplay.Spd + equipedWeapon.Spd + equipedArmor.Spd));
        }

        GameObject cubeTest = GameObject.Find("PlaceCube2");

        
        if (adventurerModel != null)
        {
            Destroy(adventurerModel);
            adventurerModel = null;   
        }
        adventurerModel = ModelSpawner.SpawnModel(adventureToDisplay, cubeTest.transform.position);
        adventurerModel.transform.rotation = Quaternion.Euler(new Vector3(-90.0f, -90.0f, 0.0f));

    }
    public PlayerData loadDataPlayer()
    {
        GameData.Initialize();
        PlayerData dataPlayer = GameData.Player;

        return dataPlayer;
    }
}
