using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentData : MonoBehaviour
{

    public int[,] cost = { { 400, 800, 1350, 2500, 4000, 5750, 8750, 15600 }, { 300, 700, 1200, 2250, 4000, 6325, 10500, 20800 } };
    /*public int money = 5000;*/
    
    public EquipmentObject[] loadAllEquip() 
    {
        EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");
        return allEquips;
    }
    //cost buat weapon dan armor
}
