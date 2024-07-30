using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prototype : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        Rank = PlayerPrefs.GetInt("PlayerRank");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("PlayerRank", Rank);
        Debug.Log("Saved " + Rank);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }
    }

    public int Rank;
    [ContextMenu("Gacha Adventurer")]
    private void Gacha()
    {
        GachaAdventurer(Rank);
    }


    // rank 0 : F, rank 1 : E ... rank 9 : SSS
    private void GachaAdventurer(int rank)
    {
        int atk = (rank * 10) + Random.Range(1, 11);
        int def = (rank * 10) + Random.Range(1, 11);
        int spd = (rank * 10) + Random.Range(1, 11);

        Debug.Log($"Atribute: ATK {atk} DEF {def} SPD {spd}");
    }
}
