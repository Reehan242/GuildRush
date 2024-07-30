using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ModelSpawner : MonoBehaviour
{
    public static GameObject SpawnModel(AdventurerData adventurer, Vector3 position) //function buat spawning nya 
    {
        GameObject _modelPrefab = Resources.Load<GameObject>("Assets/Character Assets/ModelMeleeKit 1 Variant 1");

        GameObject hair = change_hair(adventurer.hairType);



        if (adventurer != null)
        {
            GameObject model = Instantiate(_modelPrefab);
            model.transform.position = position;
            Transform hairSlot = model.transform.Find("Rigging/head/HairSlot");
            Transform bodySpot = model.transform.Find("Rigging/BodySpot");
            if (adventurer.equipedWeapon != 0)
            {
                EquipmentObject equip = getEquip(adventurer.equipedWeapon);
                Transform weaponSlot = model.transform.Find("Rigging/hand.r/WeaponSlot");
                Transform spot = model.transform.Find(findSpotType(equip.equipmentType));
                GameObject equipModel = equip.prefab;
                GameObject weaponModel = Instantiate(equipModel, weaponSlot);
                weaponModel.transform.position = spot.position;
                weaponModel.transform.rotation = spot.rotation;
                weaponModel.transform.localScale = spot.localScale;

            }

            Instantiate(hair, hairSlot);
            GameObject bodyType = Instantiate(change_body(adventurer.Class), bodySpot);
            bodyType.transform.position = bodySpot.position;
            bodyType.transform.rotation = bodySpot.rotation;
            bodyType.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            return model;
        }
        else
        {
            Debug.LogError("Prefab model belum diatur!");
            return null;
        }
    }

    public static EquipmentObject getEquip(int equipID) //function ngambil EquipmentObject yang mau ditampilin
    {
        GameData.Initialize();
        PlayerData dataPlayer = GameData.Player;
        PlayerEquipmentData dataEquip = dataPlayer.equipments.Find(obj => obj.uniqueID == equipID);
        EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");
        EquipmentObject equipModel = null;
        foreach (var equip in allEquips)
        {
            if (equip.ID == dataEquip.equipID)
            {
                equipModel = equip;
            }
        }
        return equipModel;
       
    }
    public static GameObject change_hair(int hairType) //function buat ambil model rambut yang mau ditampilin
    {
        GameObject[] hair = Resources.LoadAll<GameObject>("Assets/Character Assets/Hair");
        GameObject hairSelected = hair[hairType];
        return hairSelected;
    }

    public static string findSpotType(eqType weaponType)  //buat bedain slot equip berdasarkan tipe equipnya
    {
        string spot = "";
        switch (weaponType)
        {
            case eqType.sword:
                spot = "Rigging/hand.r/WeaponSlot/SwordSpot";
                break;
            case eqType.bow:
                spot = "Rigging/hand.r/WeaponSlot/BowSpot";
                break;
            case eqType.shield:
                spot = "Rigging/hand.r/WeaponSlot/ShieldSpot";
                break;
            case eqType.rod:
                spot = "Rigging/hand.r/WeaponSlot/RodSpot";
                break;
            case eqType.book:
                spot = "Rigging/hand.r/WeaponSlot/BookSpot";
                break;
            default:
                spot = "";
                break;
        }
        return spot;
    }

    public static GameObject change_body(string advClass) //buat set body berdasarkan class adventurer
    {
        GameObject body = null;
        switch (advClass)
        {
            case "Warrior":
                body = Resources.Load<GameObject>("Assets/Character Assets/Body/BodyWarrior");
                break;
            case "Archer":
                body = Resources.Load<GameObject>("Assets/Character Assets/Body/BodyArcher");
                break;
            case "Knight":
                body = Resources.Load<GameObject>("Assets/Character Assets/Body/BodyKnight");
                break;
            case "Priest":
                body = Resources.Load<GameObject>("Assets/Character Assets/Body/BodyPriest");
                break;
            case "Mage":
                body = Resources.Load<GameObject>("Assets/Character Assets/Body/BodyMage");
                break;
            default:
                body = null;
                break;
        }
        return body;
        
    }
}
