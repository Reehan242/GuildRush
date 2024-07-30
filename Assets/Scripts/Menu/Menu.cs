using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GuildScreen");
    }

    public void PilihAdventurer() 
    {
        SceneManager.LoadScene("AdventurerScreen");
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("MAIN SCREEN");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShopMenu()
    {
        SceneManager.LoadScene("ShopAndInventoryScene");
    }

    public void RecruitMenu()
    {
        SceneManager.LoadScene("Menu");
        
    }

    public void EquipmentMenu()
    {
        SceneManager.LoadScene("InventoryScene");
    }

    public void AdventurerScreen()
    {
        SceneManager.LoadScene("AdventurerScreen");
    }

    public void QuestMenu()
    {
        //SceneManager.LoadScene("AdventurerScreen");
        SceneManager.LoadScene("QuestScene");
    }

    public void MulaiQuest()
    {
        SceneManager.LoadScene("BattleScene");

    }

    public void MenuCastle()
    {
        SceneManager.LoadScene("Facility Screen");
    }

    public void BlacksmithMenu()
    {
        SceneManager.LoadScene("BlacksmithScreen");
    }
    public void AdventurerListMenu()
    {
        SceneManager.LoadScene("AdventurerScreenList");
    }
}
