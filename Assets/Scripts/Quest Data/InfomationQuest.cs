using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfomationQuest : MonoBehaviour
{
    public QuestData questData;
    public Text nameQuest;
    public Text description;
    public Text gold;
    public Text exp;

    void Start()
    {
        nameQuest.text = questData.NameQuest;
        description.text = questData.Description;
        gold.text = ("Gold : "+ questData.Gold.ToString());
        exp.text = ("Exp : " + questData.TrainingPoints.ToString());
    }
}
