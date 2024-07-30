using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonController : MonoBehaviour
{
    public Button SwordList;
    public Button BowList;
    public Button ShieldList;
    public Button RodList;
    public Button BookList;
    public Button HeavyArmorList;
    public Button LightArmorList;

    /*public void Start()
    {
        GameObject swordPanel = GameObject.Find("Sword Panel");
        GameObject bowPanel = GameObject.Find("Bow Panel");
        GameObject shieldPanel = GameObject.Find("Shield Panel");
        GameObject rodPanel = GameObject.Find("Rod Panel");
        GameObject bookPanel = GameObject.Find("Book Panel");
        GameObject haPanel = GameObject.Find("HA Panel");
        GameObject laPanel = GameObject.Find("LA Panel");

        SwordList.onClick.AddListener(delegate { showPanel(swordPanel, bowPanel, shieldPanel, rodPanel, bookPanel, haPanel, laPanel); });
        BowList.onClick.AddListener(delegate { showPanel(bowPanel, swordPanel, shieldPanel, rodPanel, bookPanel, haPanel, laPanel); });
        ShieldList.onClick.AddListener(delegate { showPanel(shieldPanel, bowPanel, swordPanel, rodPanel, bookPanel, haPanel, laPanel); });
        RodList.onClick.AddListener(delegate { showPanel(rodPanel, bowPanel, shieldPanel, swordPanel, bookPanel, haPanel, laPanel); });
        BookList.onClick.AddListener(delegate { showPanel(bookPanel, bowPanel, shieldPanel, rodPanel, swordPanel, haPanel, laPanel); });
        HeavyArmorList.onClick.AddListener(delegate { showPanel(haPanel, bowPanel, shieldPanel, rodPanel, bookPanel, swordPanel, laPanel); });
        LightArmorList.onClick.AddListener(delegate { showPanel(laPanel, bowPanel, shieldPanel, rodPanel, bookPanel, haPanel, swordPanel); });
    }*/
    public void Awake()
    {
        GameObject swordPanel = GameObject.Find("Sword Panel");
        GameObject bowPanel = GameObject.Find("Bow Panel");
        GameObject shieldPanel = GameObject.Find("Shield Panel");
        GameObject rodPanel = GameObject.Find("Rod Panel");
        GameObject bookPanel = GameObject.Find("Book Panel");
        GameObject haPanel = GameObject.Find("HA Panel");
        GameObject laPanel = GameObject.Find("LA Panel");
        swordPanel.SetActive(false);
        bowPanel.SetActive(false);
        shieldPanel.SetActive(false);  
        rodPanel.SetActive(false); 
        bookPanel.SetActive(false);
        haPanel.SetActive(false);
        laPanel.SetActive(false);

        SwordList.onClick.AddListener(delegate { showPanel(swordPanel, bowPanel, shieldPanel, rodPanel, bookPanel, haPanel, laPanel); });
        BowList.onClick.AddListener(delegate { showPanel(bowPanel, swordPanel, shieldPanel, rodPanel, bookPanel, haPanel, laPanel); });
        ShieldList.onClick.AddListener(delegate { showPanel(shieldPanel, bowPanel, swordPanel, rodPanel, bookPanel, haPanel, laPanel); });
        RodList.onClick.AddListener(delegate { showPanel(rodPanel, bowPanel, shieldPanel, swordPanel, bookPanel, haPanel, laPanel); });
        BookList.onClick.AddListener(delegate { showPanel(bookPanel, bowPanel, shieldPanel, rodPanel, swordPanel, haPanel, laPanel); });
        HeavyArmorList.onClick.AddListener(delegate { showPanel(haPanel, bowPanel, shieldPanel, rodPanel, bookPanel, swordPanel, laPanel); });
        LightArmorList.onClick.AddListener(delegate { showPanel(laPanel, bowPanel, shieldPanel, rodPanel, bookPanel, haPanel, swordPanel); });

    }
    public void showPanel(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f, GameObject g) 
    {
        if (a != null)
        {
            a.SetActive(true);
            b.SetActive(false);
            c.SetActive(false);
            d.SetActive(false);
            e.SetActive(false);
            f.SetActive(false);
            g.SetActive(false);
        }
        
    }
}
