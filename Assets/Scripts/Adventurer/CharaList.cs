using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharaList : MonoBehaviour
{
    public static PlayerData player;
    public GachaSystem gachaSystem;
    public GameObject UiGacha;
    public GameObject HasilGacha;
    public GameObject UiPopUP;
    public TMP_Text PopUptxt;
    public Adventurerdetails adventurerdetails;
    public GameObject splash;
    public RawImage imagesplash;

    public TextMeshProUGUI
        nameTxt1, classTxt1, statAtk1, statDef1, statSpd1, traitTxt1,
        nameTxt2, classTxt2, statAtk2, statDef2, statSpd2, traitTxt2,
        nameTxt3, classTxt3, statAtk3, statDef3, statSpd3, traitTxt3,
        RankTxt1, RankTxt2, RankTxt3;

    private AdventurerData[] AdvList = new AdventurerData[3];
    private GameObject[] advModel = new GameObject[3];
    private void Start()
    {
        GameData.Initialize();
        player = GameData.Player;
    }

    private void Update()
    {
        GameData.Initialize();
    }

    public void PencetGacha()
    {
        if (player != null)
        {
            int price = (500 + player.RankPlayer * 550 + 125 * player.RankPlayer * player.RankPlayer);
            if (player.GoldPlayer >= price )
            {
                player.GoldPlayer -= price;

                for (int i = 0; i < 3; i++)
                {
                    Debug.Log("Gacha Pressed " + (i + 1) + " Times");

                    float[] rankWeights = CalculateRankWeights();
                    int rankIndex = GetRandomWeightedRank(rankWeights);
                    int guaranteedRankAtk = GetRandomWeightedRank(rankWeights);
                    int guaranteedRankDef = GetRandomWeightedRank(rankWeights);
                    int guaranteedRankSpd = GetRandomWeightedRank(rankWeights);

                    if (guaranteedRankAtk != -1 && guaranteedRankDef != -1 && guaranteedRankSpd != -1 && rankIndex != -1)
                    {
                        AdvList[i] = gachaSystem.RandomAtribute(rankIndex, guaranteedRankAtk, guaranteedRankDef, guaranteedRankSpd, Random.Range(0, 5));
                    }
                }


                UiGacha.SetActive(false);
                HasilGacha.SetActive(true);
                UpdateUIWithRecruits();
                PlayerData.SaveDataToJson(player);
                Debug.Log($"Remaining Gold: {player.GoldPlayer}");
            }
            else
            {
                UiPopUP.SetActive(true);
                PopUptxt.text = $"Not enough gold to perform gacha, Remaining Gold: {player.GoldPlayer}";
                Debug.Log("Not enough gold to perform gacha.");
            }
        }
    }

    private int GetRandomWeightedRank(float[] weights)
    {
        float randomValue = Random.Range(0f, 100f);
        float sum = 0f;
        for (int i = 0; i < weights.Length; i++)
        {
            sum += weights[i];
            if (randomValue <= sum)
            {
                return i;
            }
        }
        return -1;
    }


    private float[] CalculateRankWeights()
    {
        float[] rankWeights = new float[9];

        // Initialize rankWeights based on player's rank
        switch (player.RankPlayer)
        {
            case 0:
                rankWeights = new float[] { 95f, 5f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
                break;
            case 1:
                rankWeights = new float[] { 10f, 90f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
                break;
            case 2:
                rankWeights = new float[] { 5f, 10f, 85f, 0f, 0f, 0f, 0f, 0f, 0f };
                break;
            case 3:
                rankWeights = new float[] { 5f, 15f, 80f, 0f, 0f, 0f, 0f, 0f, 0f };
                break;
            case 4:
                rankWeights = new float[] { 0f, 0f, 5f, 75f, 20f, 0f, 0f, 0f, 0f };
                break;
            case 5:
                rankWeights = new float[] { 0f, 0f, 0f, 0f, 5f, 20f, 75f, 0f, 0f };
                break;
            case 6:
                rankWeights = new float[] { 0f, 0f, 0f, 5f, 10f, 25f, 60f, 0f, 0f };
                break;
            case 7:
                rankWeights = new float[] { 0f, 0f, 0f, 0f, 5f, 10f, 25f, 60f, 0f };
                break;
            case 8:
                rankWeights = new float[] { 0f, 0f, 0f, 0f, 0f, 5f, 25f, 60f, 0f };
                break;
            default:
                break;
        }

        float totalWeight = rankWeights.Sum();
        for (int j = 0; j < rankWeights.Length; j++)
        {
            rankWeights[j] = (rankWeights[j] / totalWeight) * 100f;
        }

        return rankWeights;
    }

    private void UpdateUIWithRecruits()
    {
        TraitDataBase[] traitName = GameData.traitData;

        TextMeshProUGUI[] nameTexts = { nameTxt1, nameTxt2, nameTxt3 };
        TextMeshProUGUI[] RankTexts = { RankTxt1, RankTxt2, RankTxt3 };
        TextMeshProUGUI[] classTexts = { classTxt1, classTxt2, classTxt3 };
        TextMeshProUGUI[] atkTexts = { statAtk1, statAtk2, statAtk3 };
        TextMeshProUGUI[] defTexts = { statDef1, statDef2, statDef3 };
        TextMeshProUGUI[] spdTexts = { statSpd1, statSpd2, statSpd3 };
        TextMeshProUGUI[] traitText = { traitTxt1, traitTxt2, traitTxt3 };
        GameObject[] spawnerCube = new GameObject[3];
        //untuk text Tmp Trait
        //TextMeshProUGUI[] nama variabel = {trait}

        for (int i = 0; i < 3; i++)
        {
            if (AdvList[i] != null)
            {
                nameTexts[i].text = $"{AdvList[i].Name} ({gachaSystem.gender[AdvList[i].Gender]})";
                classTexts[i].text = $"Class {AdvList[i].Class}";
                RankTexts[i].text = $"{AdvList[i].Rank}";
                atkTexts[i].text = AdvList[i].Atk.ToString();
                defTexts[i].text = AdvList[i].Def.ToString();
                spdTexts[i].text = AdvList[i].Spd.ToString();

                string traitname = string.Empty;
                for (int t = 0; t < AdvList[i].TraitId.Count; t++)
                {
                    int traitIndex = AdvList[i].TraitId[t];
                    GameData.GetTraitById(traitIndex);
                    traitname += traitName[traitIndex].TraitName;
                    if (t < AdvList[i].TraitId.Count - 1)
                    {
                        traitname += "\n";
                    }
                }

                traitText[i].text = traitname;
                spawnerCube[i] = GameObject.Find("SpawningModel" +(i));
                if (advModel[i] != null)
                {
                    Destroy(advModel[i]);
                    advModel[i] = null;
                }
                advModel[i] = ModelSpawner.SpawnModel(AdvList[i], spawnerCube[i].transform.localPosition);
                advModel[i].transform.rotation = Quaternion.Euler(new Vector3(-90.0f, -90.0f, 0.0f));
                advModel[i].transform.parent = spawnerCube[i].transform;
            }
        }
    }

    public void Rekrut(int index)
    {
        if (index >= 0 && index < 3 && AdvList[index] != null)
        {
            Debug.Log("Added Adventurer " + (AdvList[index] != null));
            GameData.Player.adventurerList.Add(AdvList[index]);
            
            splash.SetActive(true);
            
            imagesplash.GetComponent<RawImage>().texture = Resources.Load<Texture>("Gacha Texture/GachaRenderTexture" + index);


            adventurerdetails.adventurerPopUp(AdvList[index]);
            PlayerData.SaveDataToJson(GameData.Player);
        }
    }
}
