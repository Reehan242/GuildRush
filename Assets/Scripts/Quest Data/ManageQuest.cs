using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManageQuest : MonoBehaviour
{
    public GameObject questPrefab;
    public Transform questTransform;
    public string folderName;
    public string questName;
    public string IDPlayer;

    Quest quest;

    PlayerData player = GameData.Player;

    private void Start()
    {
        GameData.Initialize();
        Debug.Log(GameData.Player.RankPlayer.ToSafeString());
        QuestData[] tableQuestData = Resources.LoadAll<QuestData>(folderName);
        tableQuestData = tableQuestData.OrderBy(questData => questData.ID).ToArray();
        foreach (QuestData questData in tableQuestData)
        {
            
            if (questData.questRank <= GameData.Player.RankPlayer)
            {
                GameObject questGo = Instantiate(questPrefab, questTransform);
                quest = questGo.GetComponent<Quest>();
                quest.getQuestData(questData);
                questName = questData.ToSafeString();

                Button questButton = quest.buttonChooseQuest;
                questButton.onClick.AddListener(() => GetQuestData(questData));
                questButton.onClick.AddListener(() => SceneManager.LoadScene("AdventurerScreen"));
            }
        }
    }

    

    public void GetQuestData(QuestData questData)
    {
        string selectedQuestName = questData.ToSafeString();
        string enemyName = questData.enemyData.ToSafeString();

        PlayerPrefs.SetString("SelectedQuest", selectedQuestName);
        PlayerPrefs.SetString("SelectedEnemy", enemyName);
        Debug.Log(selectedQuestName);
        Debug.Log(enemyName);
    }

    


    /*public string selectChoostQuest(QuestData questData)
    {
        string selectedQuestName = questData.ToString();
        
        //GetQuestData(selectedQuestName);
        Debug.Log(selectedQuestName);
        Debug.Log(questData.Gold + " " + questData.TrainingPoints);
        return selectedQuestName;
    }*/

}