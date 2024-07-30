using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trait Data", menuName = "Guild Rush/Trait Data")]
public class TraitDataBase : ScriptableObject
{
    public enum StatsType
    {
        AtkPercentage,
        AtkFlat,
        DeffPercentage,
        DeffFlat,
        SpdPercentage,
        SpdFlat,
        AllStats,
    }

    public enum TargetType
    {
        Self,
        RandomAlly,
        AllAllies,
        RandomEnemy,
        AllEnemies
    }

    public int TraitId;
    [SerializeField, TextArea]
    public string TraitName;
    public StatsType statsType;
    public TargetType Target;
    public int valuetStats;
    public TraitConditionData traitConditionData;
    public int UnlockRank;

    public void ApplyStatsTrait(BattleUnit ownerUnit, List<BattleUnit> allUnits)
    {
        if (traitConditionData != null)
        {
            if (!traitConditionData.IsConditionPass(ownerUnit, allUnits))
            {
                return;
            }
        }

        List<BattleUnit> targets = GetTarget(ownerUnit, allUnits);

        switch (statsType)
        {
            case StatsType.AtkPercentage:
                foreach (var target in targets)
                {
                    target.unitAttack += Mathf.CeilToInt(ownerUnit.unitAttack * valuetStats * 0.01f);
                }
                break;
            case StatsType.AtkFlat:
                foreach (var target in targets)
                {
                    target.unitAttack += valuetStats;
                }
                break;

            case StatsType.DeffPercentage:
                foreach (var target in targets)
                {
                    target.unitDefense += Mathf.CeilToInt(ownerUnit.unitDefense * valuetStats * 0.01f);
                }
                break;
            case StatsType.DeffFlat:
                foreach (var target in targets)
                {
                    target.unitDefense += valuetStats;
                }
                break;

            case StatsType.SpdPercentage:
                foreach (var target in targets)
                {
                    target.unitSpeed += Mathf.CeilToInt(ownerUnit.unitSpeed * valuetStats * 0.01f);
                }
                break;
            case StatsType.SpdFlat:
                foreach (var target in targets)
                {
                    target.unitSpeed += ownerUnit.unitSpeed;
                }
                break;

            case StatsType.AllStats:
                foreach (var target in targets)
                {
                    target.unitAttack += Mathf.CeilToInt(ownerUnit.unitAttack * valuetStats * 0.01f);
                    target.unitDefense += Mathf.CeilToInt(ownerUnit.unitDefense * valuetStats * 0.01f);
                    target.unitSpeed += Mathf.CeilToInt(ownerUnit.unitSpeed * valuetStats * 0.01f);
                }
                break;
        }
    }

    private List<BattleUnit> GetTarget(BattleUnit ownerUnit, List<BattleUnit> allUnits)
    {
        List<BattleUnit> targets = new();

        switch (Target)
        {
            case TargetType.Self:
                targets.Add(ownerUnit);
                break;

            case TargetType.AllAllies:
                List<BattleUnit> availableTargetAlly = new();
                foreach (var unit in allUnits)
                {
                    if (unit.IsEnemy == ownerUnit.IsEnemy)
                    {
                        availableTargetAlly.Add(unit);
                    }
                }

                targets.AddRange(availableTargetAlly);
                break;
            case TargetType.AllEnemies:
                List<BattleUnit> availableTargetAllEnemy = new();
                foreach (var unit in allUnits)
                {
                    if (unit.IsEnemy != ownerUnit.IsEnemy)
                    {
                        availableTargetAllEnemy.Add(unit);
                    }
                }

                targets.AddRange(availableTargetAllEnemy);
                break;
            case TargetType.RandomAlly:
                List<BattleUnit> availableTargetsRandomAlly = new();
                foreach (var unit in allUnits)
                {
                    if (unit.IsEnemy == ownerUnit.IsEnemy)
                    {
                        availableTargetsRandomAlly.Add(unit);
                    }
                }

                int randomAllyIndex = Random.Range(0, availableTargetsRandomAlly.Count);
                targets.Add(availableTargetsRandomAlly[randomAllyIndex]);
                break;
            case TargetType.RandomEnemy:
                List<BattleUnit> availableTargetsHit = new ();
                foreach (var unit in allUnits)
                {
                    if (unit.IsEnemy != ownerUnit.IsEnemy)
                    {
                        availableTargetsHit.Add(unit);
                    }
                }

                int randomEnemyIndex = Random.Range(0, availableTargetsHit.Count);
                targets.Add(availableTargetsHit[randomEnemyIndex]);
                break;
        }

        return targets;
    }
}