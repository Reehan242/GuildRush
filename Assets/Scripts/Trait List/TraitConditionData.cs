using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TraitConditionData
{
    public bool IsConditionPass(BattleUnit unit, List<BattleUnit> allUnit)
    {
        return true;
    }
}