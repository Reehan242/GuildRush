using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Adventurerdetails : MonoBehaviour
{
    private int selectedAdventurerIdx;
    public RawImage advModel;
    public AdventurerData adventurer;


    public TMP_Text NameText;
    public TMP_Text AtkText;
    public TMP_Text SpdText;
    public TMP_Text DefText;
    public TMP_Text ClassText;
    public TMP_Text TraitText;
    public Image WeaponIcon;
    public GameObject HArmorIcon;
    public GameObject LArmorIcon;
    public TMP_Text EqW_Name;
    public TMP_Text EqA_Name;
    public InventoryManager inv;
    private List<Sprite> equipIcon = new List<Sprite>();
    public GameObject messagePanel;
    

    //public void adventurerPopUp(AdventurerData adventurerData)
    //{
    //    // Your existing code...
    //    selectedAdventurerIdx = adventurerData.Index; // Assuming you have an "Index" property in AdventurerData
    //}

    public void SetSelectedAdventurerIdx(int idx)
    {
        selectedAdventurerIdx = idx;
        Debug.Log("Selected Adventurer Index: " + selectedAdventurerIdx);
    }

    public void UpdateDetailsBasedOnIndex(int idx)
    {
        if (idx != -1 && idx < GameData.Player.adventurerList.Count)
        {
            AdventurerData selectedAdventurer = GameData.Player.adventurerList[idx];
            UpdateDetails(selectedAdventurer);
        }
        else
        {
            Debug.LogError("Selected adventurer index is out of bounds.");
        }
    }

    private void UpdateDetails(AdventurerData adventurerData)
    {
        if (adventurerData != null)
        {
        	adventurer = adventurerData;
            Sprite[] allEquipIcon = Resources.LoadAll<Sprite>("Assets/Equipment Icon");
            List <EquipmentObject> items = inv.items;
            equipIcon.AddRange(allEquipIcon);

            string name = adventurerData.Name;
            string adventurerClass = adventurerData.Class;
            int hp = 100;
            int atk = adventurerData.Atk;
            int speed = adventurerData.Spd;
            int def = adventurerData.Def;
            WeaponIcon.sprite = null;
            WeaponIcon.transform.localScale = Vector3.zero;
            HArmorIcon.SetActive(false);
            LArmorIcon.SetActive(false);
            EqW_Name.text = "";
            EqA_Name.text = "";
            if (adventurerData.equipedWeapon != 0)
            {
                PlayerEquipmentData equipedWeapon = GameData.Player.equipments.Find(obj => obj.uniqueID == adventurerData.equipedWeapon);
                EquipmentObject equippedWeapon_ = items.Find(obj => obj.uniqueID == equipedWeapon.uniqueID);
                atk += equipedWeapon.Atk;
                speed += equipedWeapon.Spd;
                def += equipedWeapon.Def;
                WeaponIcon.sprite = equipIcon.Find(obj => obj.name == equippedWeapon_.eqName);
                WeaponIcon.transform.localScale = Vector3.one;
                var Name = equippedWeapon_.eqName + " (+" + (equipedWeapon.level - 1) + ")";
                if (equipedWeapon.level > 1)
                {
                    EqW_Name.text = Name;
                }
                else
                {
                    EqW_Name.text = equippedWeapon_.eqName;
                }
                
            }
            if(adventurerData.equipedArmor != 0)
            {
                PlayerEquipmentData equipedArmor = GameData.Player.equipments.Find(obj => obj.uniqueID == adventurerData.equipedArmor);
                EquipmentObject equippedArmor_ = items.Find(obj => obj.uniqueID == equipedArmor.uniqueID);
                hp += equipedArmor.hp;
                speed += equipedArmor.Spd;
                def += equipedArmor.Def;
                switch (equippedArmor_.equipmentType)
                {
                    case eqType.heavyArmor:
                        LArmorIcon.SetActive(false);
                        HArmorIcon.SetActive(true);
                        break;
                    case eqType.lightArmor:
                        HArmorIcon.SetActive(false);
                        LArmorIcon.SetActive(true);
                        break;
                    default:
                        HArmorIcon.SetActive(false);
                        LArmorIcon.SetActive(false);
                        break;
                }
                var Name = equippedArmor_.eqName + " (+" + (equipedArmor.level - 1) + ")";
                if (equipedArmor.level > 1)
                {
                    EqA_Name.text = Name;
                }
                else
                {
                    EqA_Name.text = equippedArmor_.eqName;
                }
            }
           
            string traitText = string.Empty;
            advModel.texture = Resources.Load<Texture>("Render Texture/RTadvList " + selectedAdventurerIdx);

            for (int t = 0; t < adventurerData.TraitId.Count; t++)
            {
                int trait = adventurerData.TraitId[t];
                TraitDataBase traitData = GameData.GetTraitById(trait);
                traitText += traitData.TraitName;
                if (t < adventurerData.TraitId.Count - 1)
                {
                    traitText += "\n";
                }
            }
            NameText.text = name;
            ClassText.text = adventurer.Rank + "-Rank " + adventurerClass;
            AtkText.text = atk.ToString();
            SpdText.text = speed.ToString();
            DefText.text = def.ToString();
            TraitText.text = traitText;
        }
        else
        {
            Debug.Log("null");
        }
    }

    public void adventurerPopUp(AdventurerData adventurerData)
    {
        if (adventurerData != null)
        {

            Debug.Log(" not null");
            string rank = adventurerData.Rank;
            string nama = adventurerData.Name;
            string Class = adventurerData.Class;
            int atk = adventurerData.Atk;
            int speed = adventurerData.Spd;
            int def = adventurerData.Def;
            string traitText = string.Empty;
            for (int t = 0; t < adventurerData.TraitId.Count; t++)
            {
                int trait = adventurerData.TraitId[t];
                TraitDataBase traitData = GameData.GetTraitById(trait); // store ke variable baru
                traitText += traitData.TraitName; // ngambil dari variable baru
            }

            NameText.text = nama;
            ClassText.text = rank + "-Rank " + Class;
            AtkText.text = atk.ToString();
            SpdText.text = speed.ToString();
            DefText.text = def.ToString();
            TraitText.text = "Traits\n" + traitText;
        }
        else
        {
            Debug.Log("null");
        }
    }

    public int GetSelectedAdventurerIdx()
    {
        return selectedAdventurerIdx;
    }
    public void RemoveAdvent()
    {
        List<AdventurerData> adventList = GameData.Player.adventurerList;
        if ( adventList.Count > 3)
        {
            //ini tambahan untuk melepas equip yang terpasang di adventurer saat di remove
            if (adventurer.equipedWeapon != 0)
            {
                PlayerEquipmentData equippedWeapon = GameData.Player.equipments.Find(obj => obj.uniqueID == adventurer.equipedWeapon);
                equippedWeapon.equipped = false;

            }
            if (adventurer.equipedArmor != 0)
            {
                PlayerEquipmentData equippedArmor = GameData.Player.equipments.Find(obj => obj.uniqueID == adventurer.equipedArmor);
                equippedArmor.equipped = false;
            }
            adventList.Remove(adventurer);
            PlayerData.SaveDataToJson(GameData.Player);

            // ini tambahan untuk merestart scene
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        else
        {
            messagePanel.SetActive(true);
            messagePanel.GetComponentInChildren<TextMeshProUGUI>().text = ("Unable to Remove Adventurer: Minimum of 3 Required");
            StartCoroutine(hideMessage());
        }
        
    }
    private IEnumerator hideMessage()
    {
        yield return new WaitForSeconds(3);
        messagePanel.SetActive(false);
    }
}
