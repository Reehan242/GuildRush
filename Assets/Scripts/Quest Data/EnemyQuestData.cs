using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Guild Rush/Quest Data/Enemy")]
public class EnemyQuestData : ScriptableObject
{
    public enum EnemyRanked
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

    public enum AttackType
    {
        melee,
        ranged,
        heal,
    }

    public string ID;
    public EnemyRanked enemyRank;
    public AttackType type;
    public int HealtPlayer;
    public int Attack;
    public int Deffend;
    public int Speed;
}
