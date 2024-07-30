using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class BattleUnit : MonoBehaviour
{
    public bool IsEnemy;

    [Header("Battle Unit Data")]
    public string unitName;

    public float unitHealth, unitMaxHealth = 100;
    public int unitSpeed;
    public int unitDefense;
    public int unitAttack;
    public enum AttackType
    {
        Melee,
        Ranged,
        Heal
    }

    public AttackType Type;
    public AttackType ConvertEnemyAttackType(EnemyQuestData.AttackType enemyAttackType)
    {
        switch (enemyAttackType)
        {
            case EnemyQuestData.AttackType.melee:
                return AttackType.Melee;
            case EnemyQuestData.AttackType.ranged:
                return AttackType.Ranged;
            case EnemyQuestData.AttackType.heal:
                return AttackType.Heal;
            default:
                return AttackType.Melee; 
        }
    }

    public AttackType ConvertAdventurerAttackType(string adventurerClass)
    {
        switch (adventurerClass)
        {
            case "Warrior":
            case "Knight":
                return AttackType.Melee;
            case "Archer":
            case "Mage":
                return AttackType.Ranged;
            case "Priest":
                return AttackType.Heal;
            default:
                return AttackType.Melee; 
        }
    }

    /*public AttackType AdvAtkType(AdventurerData advData)
    {
        switch()
        {

        }
        if(advData.Class == "Warrior" || advData.Class == "Knight")
        {
             AttackType.Melee;
        }
        if(advData.Class == "Archer" || advData.Class == "Mage")
        {
            AttackType.Ranged;
        }
        if(advData.Class == "Priest")
        {
            AttackType.Heal;
        }
    }*/

    [SerializeField] private HealthBar healthBar;
    public Animator myAnimator;
    GameObject advModel;

    [Header("TraitCharacter")]
    [SerializeField] public List<TraitDataBase> TraitList;

    void Awake()
    {
        
        unitHealth = unitMaxHealth;
        healthBar.UpdateHealthBar(unitMaxHealth, unitHealth);
    }
    private void Start()
    {
        GameData.Initialize();
    }

    public void ApplyTraits(List<BattleUnit> allUnits)
    {
        foreach (TraitDataBase trait in TraitList)
        {
            trait.ApplyStatsTrait(this, allUnits);
        }
    }

    //public void GetCharacterData()
    //{
    //    string enemyDataName = PlayerPrefs.GetString("SelectedEnemy");
    //    EnemyQuestData enemyData = Resources.Load<EnemyQuestData>("EnemyData/" + enemyDataName);
    //    if (enemyData != null)
    //    {
    //        battleUnit = GetComponent<BattleUnit>();
    //        battleUnit.InitializeEnemy(enemyData);
    //    }
    //}

    public void InitializeEnemy(EnemyQuestData enemyData)
    {
        if (enemyData != null && IsEnemy == true)
        {
            EnemyQuestData.EnemyRanked rank = enemyData.enemyRank;
            Type = ConvertEnemyAttackType(enemyData.type);
            unitMaxHealth = enemyData.HealtPlayer;
            unitSpeed = enemyData.Speed;
            unitDefense = enemyData.Deffend;
            unitAttack = enemyData.Attack;
        }
    }

    public void InitializeParty(AdventurerData partyData)
    {
        GameData.Initialize();
        List<PlayerEquipmentData> equipment = GameData.Player.equipments;
        if (partyData != null && IsEnemy ==false)
        {
            unitMaxHealth = 100;
            unitName = partyData.Name;
            int atk = partyData.Atk;
            int spd = partyData.Spd;
            int def = partyData.Def;
            if(partyData.equipedWeapon != 0)
            {
                PlayerEquipmentData equippedWeapon = equipment.Find(obj => obj.uniqueID == partyData.equipedWeapon);
                atk += equippedWeapon.Atk;
                spd += equippedWeapon.Spd;
                def += equippedWeapon.Def;
            }
            if (partyData.equipedArmor != 0)
            {
                PlayerEquipmentData equippedArmor = equipment.Find(obj => obj.uniqueID == partyData.equipedArmor);
                unitMaxHealth += equippedArmor.hp;
                spd += equippedArmor.Spd;
                def += equippedArmor.Def;
            }
            
            unitAttack = atk;
            unitDefense = def;
            unitSpeed = spd;
            Type = ConvertAdventurerAttackType(partyData.Class);
            TraitList = new List<TraitDataBase>();
            for (int t = 0; t < partyData.TraitId.Count; t++)
            {
                TraitDataBase traitData = GameData.GetTraitById(partyData.TraitId[t]);
                TraitList.Add(traitData);
            }
            Transform modelSlot = transform;
            advModel = ModelSpawner.SpawnModel(partyData, modelSlot.position);
            advModel.transform.parent = transform;
            advModel.transform.rotation = Quaternion.Euler(new Vector3(-90.0f, 180.0f, 0.0f));
            advModel.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            myAnimator = advModel.GetComponentInChildren<Animator>();
        }
    }

    public bool isAlive()
    {
        if (unitHealth > 0)
        {
            return true;
        }
        else
            return false;
    }
    public void TakeDamage(int dmg)
    {
        
        if (dmg <= unitDefense)
        {
            unitHealth -= 2;
        }
        else
        {
            unitHealth -= (dmg - unitDefense);
            
        }
        healthBar.UpdateHealthBar(unitMaxHealth, unitHealth);
        /*if (unitHealth >= 0)
			return true;
		else
			return false;*/
    }

    public void Heal(int amount)
    {
        unitHealth += amount;
        if (unitHealth > unitMaxHealth)
            unitHealth = unitMaxHealth;

        healthBar.UpdateHealthBar(unitMaxHealth, unitHealth);
    }


    // TODO: pindahin ke battle system aja
    

    public void UnitAttack(BattleUnit unit, List<BattleUnit> allUnits)
    {

        if (unit.isAlive())
        {
            var attackTarget = GetTarget(unit, allUnits);
            Vector3 initialPosition = unit.transform.position;
            Vector3 initTargetPosition = new Vector3(attackTarget.transform.position.x, attackTarget.transform.position.y, attackTarget.transform.position.z);
            // nyerangnya ngapain

            if (attackTarget != null)
            {
                //myAnimator.Play("AttackAnimation");
                myAnimator.SetTrigger("Attack");
                
                // Menggunakan switch case berdasarkan tipe serangan
                switch (unit.Type)
                {
                    case BattleUnit.AttackType.Melee:
                        if (!unit.IsEnemy)
                        {
                            
                            
                            unit.transform.DOJump(new Vector3(attackTarget.transform.position.x - 2, attackTarget.transform.position.y, attackTarget.transform.position.z), 5, 1, 1.0f, false)
                            .OnComplete(() => OnActionComplete(unit, allUnits));
                            attackTarget.transform.DOShakePosition(1.0f, 1.0f, 10, 3, false, true, default).SetDelay(1f);
                            unit.transform.DOMove(initialPosition, 1.5f).SetDelay(1.5f);
                            
                        }
                        else
                        {
                            //myAnimator.SetTrigger("IsAttacking");
                            //myAnimator.SetBool("IsIdling", false);
                            //attackTarget.myAnimator.SetTrigger("IsTakingDamage");
                            //Debug.Log(unit.name + " attacking " + attackTarget.name + ". health left " + attackTarget.unitHealth);
                            unit.transform.DOJump(new Vector3(attackTarget.transform.position.x + 2, attackTarget.transform.position.y, attackTarget.transform.position.z), 5, 1, 1.0f, false)
                            .OnComplete(() => OnActionComplete(unit, allUnits));
                            attackTarget.transform.DOShakePosition(1.0f, 1.0f, 10, 3, false, true, default).SetDelay(1f);
                            unit.transform.DOMove(initialPosition, 1.5f).SetDelay(1.5f);
                            
                        }
                        break;
                    case BattleUnit.AttackType.Ranged:
                        if (!unit.IsEnemy)
                        {
                            //Debug.Log(unit.name + " attacking " + attackTarget.name + ". health left " + attackTarget.unitHealth);
                            unit.transform.DOMoveX(-7, 1f, false)
                            .OnComplete(() => OnActionComplete(unit, allUnits));
                            attackTarget.transform.DOShakePosition(1.0f, 1.0f, 10, 3, false, true, default).SetDelay(1f);
                            unit.transform.DOMove(initialPosition, 1.5f).SetDelay(1.5f);
                        }
                        else
                        {
                            //Debug.Log(unit.name + " attacking " + attackTarget.name + ". health left " + attackTarget.unitHealth);
                            unit.transform.DOMoveX(7, 1f, false)
                            .OnComplete(() => OnActionComplete(unit, allUnits));
                            attackTarget.transform.DOShakePosition(1.0f, 1.0f, 10, 3, false, true, default).SetDelay(1f);
                            unit.transform.DOMove(initialPosition, 1.5f).SetDelay(1.5f);
                        }
                        break;
                    case BattleUnit.AttackType.Heal:
                        if (!unit.IsEnemy)
                        {
                            
                            unit.transform.DOMoveX(-7, 1f, false)
                            .OnComplete(() => OnActionComplete(unit, allUnits));
                            attackTarget.transform.DOJump(new Vector3(attackTarget.transform.position.x, attackTarget.transform.position.y, attackTarget.transform.position.z), 2, 1, 1.0f, false).SetDelay(1f);
                            unit.transform.DOMove(initialPosition, 1.5f).SetDelay(1.5f);
                            //attackTarget.Heal(unit.unitAttack);
                        }
                        else
                        {
                            //Debug.Log(unit.name + " healing " + attackTarget.name + ". health left " + attackTarget.unitHealth);
                            unit.transform.DOMoveX(7, 1f, false)
                            .OnComplete(() => OnActionComplete(unit, allUnits));
                            attackTarget.transform.DOJump(new Vector3(attackTarget.transform.position.x, attackTarget.transform.position.y, attackTarget.transform.position.z), 2, 1, 1.0f, false).SetDelay(1f);
                            unit.transform.DOMove(initialPosition, 1.5f).SetDelay(1.5f);
                            //attackTarget.Heal(unit.unitAttack);
                        }
                        break;
                }
                


                if (!attackTarget.isAlive())
                {
                    //attackTarget.transform.DOShakePosition(1.0f, 1.0f, 20, 3, false, true, default);
                    
                }
            }
        }
    }

    public void OnActionComplete(BattleUnit unit, List<BattleUnit> allUnits)
    {
        var attackTarget = GetTarget(unit, allUnits);
        if(unit.Type == AttackType.Melee || unit.Type == AttackType.Ranged)
        {
            attackTarget.myAnimator.SetTrigger("TakeDamage");
            attackTarget.TakeDamage(unit.unitAttack);
            Debug.Log(unit.name + " attacking " + attackTarget.name + ". health left " + attackTarget.unitHealth);
        }

        if(unit.Type == AttackType.Heal)
        {
            attackTarget.Heal(unit.unitAttack);
            Debug.Log(unit.name + " healing " + attackTarget.name + ". health left " + attackTarget.unitHealth);
        }

        if(!attackTarget.isAlive())
        {
            attackTarget.myAnimator.SetTrigger("Death");
        }
    }

    private BattleUnit GetTarget(BattleUnit attacker, List<BattleUnit> allUnits)
    {
        List<BattleUnit> targetCandidate = new List<BattleUnit>();

        // melee
        switch (attacker.Type)
        {
            case BattleUnit.AttackType.Melee:
                foreach (var unit in allUnits)
                {
                    if (!unit.isAlive())
                    {
                        continue;
                    }

                    if (unit.IsEnemy == attacker.IsEnemy)
                    {
                        continue;
                    }

                    targetCandidate.Add(unit);
                    return unit;
                }
                break;

            case BattleUnit.AttackType.Ranged:
                foreach (var unit in allUnits)
                {
                    if (!unit.isAlive())
                    {
                        continue;
                    }

                    if (unit.IsEnemy == attacker.IsEnemy)
                    {
                        continue;
                    }

                    targetCandidate.Add(unit);
                }

                if (targetCandidate.Count > 0)
                {
                    var idx = Random.Range(0, targetCandidate.Count);
                    return targetCandidate[idx];
                }
                break;

            case BattleUnit.AttackType.Heal:
                BattleUnit lowestHealthUnit = null;
                foreach (var unit in allUnits)
                {
                    if (!unit.isAlive() || unit.IsEnemy != attacker.IsEnemy)
                    {
                        continue;
                    }

                    if (lowestHealthUnit == null || unit.unitHealth < lowestHealthUnit.unitHealth)
                    {
                        lowestHealthUnit = unit;
                    }
                }

                return lowestHealthUnit;
        }

        return null;
    }
}