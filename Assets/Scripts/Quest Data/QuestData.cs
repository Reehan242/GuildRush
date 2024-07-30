using UnityEngine;

[CreateAssetMenu(fileName = "New Quest Data", menuName = "Guild Rush/Quest Data")]
public class QuestData : ScriptableObject
{
    public enum QuestRank
    {
        F,
        E,
        D,
        C,
        B,
        A,
        S,
        SS,
        SSS
    }

    public int questRank;
    public int ID;
    public string NameQuest;
    public string Description;
    public EnemyQuestData[] enemyData;
    public int exp;
    public int TrainingPoints;
    public int Gold;
    public int guildRankReward;
}
