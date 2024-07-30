using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentData
{
    
    public static int[,] cost = { { 400, 800, 1350, 2500, 4000, 5750, 8750, 15600 }, { 300, 700, 1200, 2250, 4000, 6325, 10500, 20800 } };

    //atk , def, spd
    public static int[,] statGrowth = { {1,1,1,1,1,0,0,2,2,1,2,1,0,0,3,3,2,3,2,0,0,4,4,3,4,3,0,0,5,5,4,5,4,0,0,6,6,5,6,5,0,0,7,7,6,7,6,0,0,8,8,7,8,7,0,0},
        {1,1,1,1,1,0,0,2,1,2,1,2,0,0,3,2,3,2,3,0,0,4,3,4,3,4,0,0,5,4,5,4,5,0,0,6,5,6,5,6,0,0,7,6,7,6,7,0,0,8,7,8,7,8,0,0 },
        {1,1,1,1,1,0,0,1,2,2,2,2,0,0,2,3,3,3,3,0,0,3,4,4,4,4,0,0,4,5,5,5,5,0,0,5,6,6,6,6,0,0,6,7,7,7,7,0,0,7,8,8,8,8,0,0 } };
    public static EquipmentObject[] loadAllEquip() 
    {
        EquipmentObject[] allEquips = Resources.LoadAll<EquipmentObject>("Equipment");
        return allEquips;
    }

    public static GameObject[] loadEquipAssets()
    {

        GameObject[] allEuipAsset = Resources.LoadAll<GameObject>("Assets/Equipment Assets");
        return allEuipAsset;
    }

    
    //cost buat weapon dan armor
}
