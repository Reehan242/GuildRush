using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class TestingEquip : MonoBehaviour
{
#if UNITY_EDITOR
    public EquipmentObject equipment;
    public EquipmentObject armor;
    public classType advClass;
    public int hp, atk, def, spd;
    int newHp, newAtk, newDef, newSpd;
    public Button testingButton;
    bool paired_type;
    private void Start()
    {
        testingButton.onClick.AddListener(cobacoba);
    }
    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
    public void cobacoba()
    {
        newHp = hp;
        newAtk = atk;
        newDef = def;
        newSpd = spd;
        ClearLog();
        if (equipment != null)
        {
            Debug.Log("Equiped with " + equipment.eqName + "\nWeapon Stats: \nATK = " 
            + equipment.atkBonus + " DEF = " + equipment.defBonus + " SPD = " + equipment.spdBonus+"\n");
            newAtk += equipment.atkBonus; newDef += equipment.defBonus; newSpd += equipment.spdBonus;
            
        }
        else
        {
            Debug.Log("No weapon selected..." + "\n\n");
        }
        
        if (armor != null)
        {
            Debug.Log("Equiped with " + armor.eqName + "\nArmor Stats : \nHP = " 
            + armor.hpBonus + " DEF = " + armor.defBonus + " SPD = " + armor.spdBonus+"\n");
            newHp += armor.hpBonus; newDef += armor.defBonus; newSpd += armor.spdBonus;
        }
        else
        {
            Debug.Log("No armor selected..." + "\n\n");
        }
        Debug.Log("Base Stats: \nHP = " + hp + " ATK = " + atk + " DEF = " + def + " SPD = " + spd 
        +"\n\n New Stats : \nHP = "+newHp+" ATK = "+newAtk+" DEF = "+newDef
        +" SPD = " + newSpd+"\n\n");


    }
    public bool check_class() 
    {
        switch(advClass)
        {
            case classType.Swordman:
                if (equipment.equipmentType == eqType.sword) 
                {
                    paired_type = true;
                }
                else 
                { 
                    paired_type = false; 
                }
                break;
            case classType.Bowman:
                if (equipment.equipmentType == eqType.bow)
                {
                    paired_type = true;
                }
                else
                {
                    paired_type = false;
                }
                break;
            case classType.Shieldman:
                if (equipment.equipmentType == eqType.shield)
                {
                    paired_type = true;
                }
                else
                {
                    paired_type = false;
                }
                break;
            case classType.Mage:
                if (equipment.equipmentType == eqType.rod)
                {
                    paired_type = true;
                }
                else
                {
                    paired_type = false;
                }
                break;
            case classType.Healer:
                if (equipment.equipmentType == eqType.book)
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
    public void Update()
    {
        if (equipment != null) 
        {
            if (check_class() == false) 
            {
                Debug.Log("Weapon class not match");
                equipment = null;
            }
        }
        if (equipment != null && equipment.type != ItemType.Weapon) 
        {
            Debug.Log("Equipment type not match");
            equipment = null;
        }
        if (armor != null && armor.type != ItemType.Armor) 
        {
            Debug.Log("Equipment type not match");
            armor = null;
        }
    }

    public enum classType 
    {
        Swordman,
        Bowman,
        Shieldman,
        Mage,
        Healer
    }
#endif
}
