using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;



public enum BattleState
{
    START, WAITFORTURN, CHARACTER1TURN, CHARACTER2TURN, CHARACTER3TURN,
    ENEMY1TURN, ENEMY2TURN, ENEMY3TURN, WON, LOST
}

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform[] playerBattleStation;
    public Transform[] enemyBattleStation;
    GameObject playerGO;
    GameObject enemyGO;

    //int gold;
    //int trainingPoints;

    public BattleState state;

    List<BattleUnit> allUnits = new List<BattleUnit>();

    BattleUnit fastestUnit;
    

    [Header("PanelScreen")]
    [SerializeField] GameObject pauseMenuScreen;
    [SerializeField] GameObject DefeatScreen;
    [SerializeField] GameObject VictoryScreen;
    [SerializeField] GameObject speedButton;
    [SerializeField] GameObject reverseSpeedButton;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI rankRewardText;

    private List<BattleUnit> _attackedUnits = new List<BattleUnit>();
    //private List<EnemyQuestData> _enemyUnits = new List<EnemyQuestData>();

    private QuestData _selectedQuest;
    int questId;

    public void ReceiveQuestReward()
    {
        GameData.Initialize();
        
        
        questId = _selectedQuest.ID;

        if(GameData.Player.ClearedQuestIds.Contains(questId))
        {
            GameData.Player.GoldPlayer += _selectedQuest.Gold;
        }
        else
        {
            GameData.Player.GoldPlayer += _selectedQuest.Gold;
            GameData.Player.RankPlayer += _selectedQuest.guildRankReward;
            if(_selectedQuest.guildRankReward > 0)
            {
                rankRewardText.text = "CONGRATULATION, YOU HAVE RANKED UP!";
            }
            GameData.Player.ClearedQuestIds.Add(questId);
        }
        PlayerData.SaveDataToJson(GameData.Player);
        UpdateQuestRewardUI();
    }

    public void UpdateQuestRewardUI()
    {
        if (goldText != null)
        {
            goldText.text = _selectedQuest.Gold+ " Gold";
        }
        /*if (rankRewardText != null)
        {
            rankRewardText.text = "Rank Reward: " + _selectedQuest.guildRankReward;
        }*/
    }

    private void Start()
    {   
        GameData.Initialize();
        string selectedQuestName = PlayerPrefs.GetString("SelectedQuest");
        Debug.Log("Selected Quest in BattleSystem: " + selectedQuestName);
        _selectedQuest = GetQuestData(selectedQuestName);
        Debug.Log("selected quest " + _selectedQuest.enemyData[0].name);
        state = BattleState.START;
        StartCoroutine(SetupBattle());

        pauseMenuScreen.SetActive(true);
        DefeatScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        
    }
    
    public QuestData GetQuestData(string questName)
    {
        string questPath = "Quest/" + questName;
        QuestData selectedQuestData = Resources.Load<QuestData>(questPath);

        return selectedQuestData;
    }


    IEnumerator SetupBattle()
    {
        Time.timeScale = 1;
        allUnits = new List<BattleUnit>();
        int battleUnitIndex = 0;
        foreach(var advId in GameData.Player.Party)
        {
            if (advId >= 0 && advId < GameData.Player.adventurerList.Count)
            {
                AdventurerData adventurer = GameData.Player.adventurerList[advId];

                // Lakukan sesuatu dengan adventurer yang ditemukan
                Debug.Log("ID: " + GameData.Player.adventurerList[advId] + ", Nama: " + adventurer.Name + adventurer.Atk + adventurer.Def);
                
                //playerGO = Instantiate(playerPrefab, playerBattleStation[battleUnitIndex]);
                if(adventurer.Class == "Warrior" || adventurer.Class == "Knight")
                {
                    playerGO = Instantiate(playerPrefab, playerBattleStation[battleUnitIndex]);
                }
                if(adventurer.Class == "Archer" || adventurer.Class == "Mage" || adventurer.Class == "Priest")
                {
                    playerGO = Instantiate(playerPrefab, playerBattleStation[3+battleUnitIndex]);
                }
                BattleUnit adventUnit = playerGO.GetComponent<BattleUnit>();
            
                adventUnit.InitializeParty(adventurer);
                playerGO.SetActive(true);
                playerGO.transform.localPosition = Vector3.zero;
                allUnits.Add(playerGO.GetComponent<BattleUnit>());
                battleUnitIndex++;
            }
            else
            {
                Debug.Log("ID tidak valid: " + advId);
            }

        }
        

        // TODO: ubah enemy di selected quest jadi list/array
        for (int i = 0; i < _selectedQuest.enemyData.Length ; i++)
        {
            if(_selectedQuest.enemyData[i].type == EnemyQuestData.AttackType.melee)
            {
                enemyGO = Instantiate(enemyPrefab, enemyBattleStation[i]);
            }
            if(_selectedQuest.enemyData[i].type == EnemyQuestData.AttackType.ranged || _selectedQuest.enemyData[i].type == EnemyQuestData.AttackType.heal)
            {
                enemyGO = Instantiate(enemyPrefab, enemyBattleStation[3+i]);
            }
            BattleUnit enemyUnit = enemyGO.GetComponent<BattleUnit>();
            enemyUnit.InitializeEnemy(_selectedQuest.enemyData[i]);
            enemyGO.SetActive(true);
            enemyGO.transform.localPosition = Vector3.zero;
            allUnits.Add(enemyGO.GetComponent<BattleUnit>());
        }

        foreach(var unit in allUnits)
        {
            unit.ApplyTraits(allUnits);
        }

        yield return new WaitForSeconds(1f);

        state = BattleState.WAITFORTURN;
        StartCoroutine(WaitForTurn());
    }

    IEnumerator WaitForTurn()
    {
        fastestUnit = null;

        foreach (BattleUnit unit in allUnits)
        {
            CheckAttackedUnits(allUnits, _attackedUnits);
            if (!unit.isAlive())
            {
                continue;
            }

            if (_attackedUnits.Contains(unit))
            {
                continue;
            }


            if (fastestUnit == null)
            {
                fastestUnit = unit;
            }
            else
            {
                if (unit.unitSpeed > fastestUnit.unitSpeed)
                {
                    fastestUnit = unit;
                }
            }
        }

        if (fastestUnit != null)
        {
            Debug.Log("fastest " + fastestUnit.name + " attacked " + _attackedUnits.Count);
            fastestUnit.UnitAttack(fastestUnit, allUnits);
            _attackedUnits.Add(fastestUnit);
        }

        yield return new WaitForSeconds(2f);

        if(!CheckEndBattle())
        {
            StartCoroutine(WaitForTurn());
        }
    }

    public void CheckAttackedUnits(List<BattleUnit> allUnits, List<BattleUnit> _attackedUnits)
    {
        var aliveUnits = new List<BattleUnit>();
        foreach (var unit in allUnits)
        {
            if (unit.isAlive())
            {
                aliveUnits.Add(unit);
            }
        }

        if (_attackedUnits.Count >= aliveUnits.Count)
        {
            _attackedUnits.Clear();
        }
    }
    
    bool CheckEndBattle()
    {
        int enemyCount = 0;
        int enemyDeadCount = 0;
        int allyCount = 0;
        int allyDeadCount = 0;

        foreach(var unit in allUnits)
        {
            if(unit.IsEnemy)
            {
                enemyCount++;

                if(!unit.isAlive())
                {
                    enemyDeadCount++;
                }
            }
            else
            {
                allyCount++;

                if(!unit.isAlive())
                {
                    allyDeadCount++;
                }
            }
        }

        if(enemyDeadCount == enemyCount)
        {
            // menang
            for (int i = 0; i < allUnits.Count; i++)
            {
                Destroy(allUnits[i].gameObject);
            }
            
            Time.timeScale = 0;
            VictoryScreen.SetActive(true);
            pauseMenuScreen.SetActive(false);
            speedButton.SetActive(false);
            reverseSpeedButton.SetActive(false);
            ReceiveQuestReward();
            
            //goldText.text = gold.ToString() + "Gold";
            //trainingPointsText.text = trainingPoints.ToString() + "Training Points";
            return true;
        }
        else if(allyDeadCount == allyCount)
        {
            for (int i = 0; i < allUnits.Count; i++)
            {
                Destroy(allUnits[i].gameObject);
            }
            Time.timeScale = 0;
            DefeatScreen.SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    /*public void GoToMenu()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
        VictoryScreen.SetActive(false);
        DefeatScreen.SetActive(false);
        pauseMenuScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }*/

    public void RestartGame()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
        DefeatScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        SceneManager.LoadScene(3);
    }

    public void TwoTimeSpeed()
    {
        Time.timeScale = 4;
        
    }

    public void OnePFiveSpeed()
    {
        Time.timeScale = 2;
    }

    public void ReverseTimeSpeed()
    {
        Time.timeScale = 1;
        
    }
}
