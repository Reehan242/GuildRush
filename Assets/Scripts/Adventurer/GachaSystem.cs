using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public string[] gender, names;
    public float[] rankValue;
    public string folderTraitName = "TraitList";

    private string[] rankGa = {"F","E","D","C","B","A","S","SS","SSS"};
    private int[] Rank = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    private string[] classGa = {"Warrior","Archer","Knight","Mage","Priest"};

    //public class AdventurerData
    //{
    //    public int nameGacha { get; set; }
    //    public int AtkGacha { get; set; }
    //    public int DefGacha { get; set; }
    //    public int SpdGacha { get; set; }
    //    public int GenGacha { get; set; }
    //    public string rankGacha { get; set; }
    //    public string classGacha { get; set; }
    //}

    public AdventurerData RandomAtribute(int rank, int rankAtk, int rankDef, int rankSpd, int classtype)
    {
        AdventurerData AdvData = new AdventurerData();

        AdvData.Rank = rankGa[rank];
        AdvData.Class = classGa[classtype];
        
        AdvData.Gender = Random.Range(0, 2);
        if(AdvData.Gender == 1)
        {
            int randomNumber = Random.Range(0, 101);
            AdvData.hairType = randomNumber % 5;
        }
        else 
        {
            int randomNumber = Random.Range(0, 101);
            AdvData.hairType = (randomNumber % 2)+5;          
        }
        
        AdvData.Name = names[Random.Range(0, 20)];

        List<int> listTrait = getTraitAdventurer();
        AdvData.TraitId = listTrait;

        if (classtype == 0)
        {
            if (rank == 0)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 7)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 7)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 7)));
            }

            else if (rank == 1)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 3)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 3)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 2)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 4)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 5)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 3)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 5)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 4)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 5)));
            }

            else if (rank == 4)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 6)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 4)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 5)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 6)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 5)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 5)));
            }

            else if (rank == 6)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 4)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 4)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 7)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 5)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 4)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 8)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 9)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 9)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 9)));
            }

        }
        else if (classtype == 1)
        {
            if (rank == 0)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 5)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 1)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 7)));
            }

            else if (rank == 1)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 4)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 1)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 6)));
            }

            else if (rank == 2)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 5)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 2)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 7)));
            }

            else if (rank == 3)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 3)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 2)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 9)));
            }

            else if (rank == 4)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 4)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 3)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 9)));
            }

            else if (rank == 5)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 6)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 4)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 10)));
            }

            else if (rank == 6)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 7)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 3)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 10)));
            }

            else if (rank == 7)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 6)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 3)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 9)));
            }

            else if (rank == 8)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 9)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 6)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 16)));
            }
        }
        else if (classtype == 2)
        {
            if (rank == 0)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 2)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 9)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 1)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 2)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 9)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 2)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 3)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 8)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 5)));
            }

            else if (rank == 3)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 3)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 9)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 4)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 2)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 9)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 5)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 2)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 11)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 6)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 2)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 11)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 7)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 2)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 11)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 8)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 3)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 16)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }
        }
        else if (classtype == 3)
        {
            if (rank == 0)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 7)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 2)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 1)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 7)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 3)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 2)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 7)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 5)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 3)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 8)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 6)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 6)));
            }

            else if (rank == 4)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 10)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 4)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 5)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 11)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 4)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 6)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 11)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 4)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 4)));
            }

            else if (rank == 7)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 11)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 2)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 8)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 14)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 3)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 7)));
            }
        }

        else
        {
            if (rank == 0)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 3)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 6)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 6)));
            }

            else if (rank == 1)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 3)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 6)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 7)));
            }

            else if (rank == 2)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 4)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 5)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 6)));
            }

            else if (rank == 3)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 4)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 6)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 5)));
            }

            else if (rank == 4)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 2)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 3)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 5)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 4)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 3)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 6)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 4)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 3)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 3)));
            }

            else if (rank == 7)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 3)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 5)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 5)));
            }

            else if (rank == 8)
            {
                AdvData.Atk = Mathf.Max(1, (rankAtk * 10) + (Random.Range(0, 6)));
                AdvData.Def = Mathf.Max(1, (rankDef * 10) + (Random.Range(0, 7)));
                AdvData.Spd = Mathf.Max(1, (rankSpd * 10) + (Random.Range(0, 8)));
            }
        }

        return AdvData;
    }


    public AdventurerData GachaAdventurer()
    {
        float change = Random.Range(0.0f, 101f);
        //Debug.Log(change);
        int tier = Random.Range(0, 5);
        for (int i = 8; i >= 0; i--)
        {
            if (change <= rankValue[i])
            {
                //Debug.Log(i);
                return RandomAtribute(i, i, i, i, tier);
            }
        }
        return null;
    }

    public List<int> getTraitAdventurer()
    {
        int traitSlot = Random.Range(0, 3);
        List<int> listTraitId = new();
        for (int i = 0; i < traitSlot; i++)
        {
            TraitDataBase[] traitFolder = Resources.LoadAll<TraitDataBase>(folderTraitName);

            List<TraitDataBase> unlockedTraits = new();
            foreach(var trait in traitFolder)
            {
                if(GameData.Player.RankPlayer >= trait.UnlockRank)
                {
                    unlockedTraits.Add(trait); 
                }
            }
 
            int randomTrait = Random.Range(0, unlockedTraits.Count);
            if (!listTraitId.Contains(unlockedTraits[randomTrait].TraitId))
            {
                listTraitId.Add(unlockedTraits[randomTrait].TraitId);
            }
        }

        return listTraitId;
    }
}