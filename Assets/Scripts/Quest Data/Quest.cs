using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Text nameQuest;
    public Text description;
    public Text Reward;
    public Text Rank;
    public Text AscendQuest;
    public Button buttonChooseQuest;

    QuestData questData;

    public void getQuestData(QuestData quest)
    {
        questData = quest;

        nameQuest.text = questData.NameQuest.ToString();
        description.text = questData.Description.ToString();
        Reward.text = ("Reward :    " + questData.Gold.ToString() + " Gold");
        Rank.text = ("Rank :   " + getQuestRankString(questData));
        if(questData.guildRankReward > 0)
        {
            AscendQuest.text = "[Ascension Quest ! ]";
        }
        else
        {
            AscendQuest.text = "";

        }
    }

    public string getQuestRankString(QuestData quest)
    {
        switch(quest.questRank)
        {
            case 0:
                return "F";
            case 1:
                return "E";
            case 2:
                return "D";
            case 3:
                return "C";
            case 4:
                return "B";
            case 5:
                return "A";
            case 6:
                return "S";
            case 7:
                return "SS";
            case 8:
                return "SSS";
            default:
                return "Unknown";
        }
    }
}
