using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestData : MonoBehaviour
{
    public List<int> listQuestData = new List<int>();

    void AddQuest(QuestData questData)
    {
        listQuestData.Add(questData.ID);
    }
}
