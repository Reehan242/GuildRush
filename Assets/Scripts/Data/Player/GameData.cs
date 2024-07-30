using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameData
{
    public static PlayerData Player;
    public static int[,] statGrowth = { {1,1,1,1,1,0,0,2,2,1,2,1,0,0,3,3,2,3,2,0,0,4,4,3,4,3,0,0,5,5,4,5,4,0,0,6,6,5,6,5,0,0,7,7,6,7,6,0,0,8,8,7,8,7,0,0},//atk
        {1,1,1,1,1,0,0,2,1,2,1,2,0,0,3,2,3,2,3,0,0,4,3,4,3,4,0,0,5,4,5,4,5,0,0,6,5,6,5,6,0,0,7,6,7,6,7,0,0,8,7,8,7,8,0,0 },//def
        {1,1,1,1,1,0,0,1,2,2,2,2,0,0,2,3,3,3,3,0,0,3,4,4,4,4,0,0,4,5,5,5,5,0,0,5,6,6,6,6,0,0,6,7,7,7,7,0,0,7,8,8,8,8,0,0 } };//spd

    public static TraitDataBase[] traitData;

    public static void Initialize()
    {
        // TODO: load data
        traitData = Resources.LoadAll<TraitDataBase>("TraitList");

        Player = PlayerData.LoadDataFromJson();
    }

    public static TraitDataBase GetTraitById(int id)
    {
        return traitData.FirstOrDefault(trait => trait.TraitId == id);
    }
}
