using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class spawnAssets : MonoBehaviour
{
    public GameObject assetsSpawned;
    public GameObject LarmorSprite;
    public GameObject HarmorSprite;
    
    public void createDisplay(GameObject a, EquipmentObject b)
    {
        LarmorSprite.SetActive(false);
        HarmorSprite.SetActive(false);
        GameObject cubeTest = GameObject.Find("PlaceCube");
        if(assetsSpawned != null) 
        {
            Destroy(assetsSpawned);
        }
        
        if (b.equipmentType == eqType.sword)
        {
            assetsSpawned = Instantiate(a);
            assetsSpawned.transform.position = new Vector3(cubeTest.transform.position.x, cubeTest.transform.position.y - 1, cubeTest.transform.position.z);
            assetsSpawned.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            assetsSpawned.transform.transform.rotation = Quaternion.Euler(new Vector3(-90.0f, 0.0f, 270.0f));
        }
        else if (b.equipmentType == eqType.shield)
        {
            assetsSpawned = Instantiate(a);
            assetsSpawned.transform.position = new Vector3(cubeTest.transform.position.x, cubeTest.transform.position.y+2,cubeTest.transform.position.z);
            assetsSpawned.transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
            assetsSpawned.transform.transform.rotation = Quaternion.Euler(new Vector3(-90.0f, 0.0f, 270.0f));
        }
        else if (b.equipmentType == eqType.bow)
        {
            assetsSpawned = Instantiate(a);
            assetsSpawned.transform.position = new Vector3(cubeTest.transform.position.x, cubeTest.transform.position.y + 2, cubeTest.transform.position.z);
            assetsSpawned.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            assetsSpawned.transform.transform.rotation = Quaternion.Euler(new Vector3(-180.0f, -90.0f, 0.0f));
        }
        else if (b.equipmentType == eqType.book)
        {
            assetsSpawned = Instantiate(a);
            assetsSpawned.transform.position = new Vector3(cubeTest.transform.position.x, cubeTest.transform.position.y + 1, cubeTest.transform.position.z);
            assetsSpawned.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            assetsSpawned.transform.transform.rotation = Quaternion.Euler(new Vector3(-90.0f, 0.0f, 270.0f));
        }
        else if (b.equipmentType == eqType.rod)
        {
            assetsSpawned = Instantiate(a);
            assetsSpawned.transform.position = new Vector3(cubeTest.transform.position.x, cubeTest.transform.position.y + 3, cubeTest.transform.position.z);
            assetsSpawned.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
            assetsSpawned.transform.transform.rotation = Quaternion.Euler(new Vector3(-90.0f, 0.0f, 270.0f));
        }
       
        else
        {
            Debug.Log("Assets Belum Ada");
        }
    }
    public void createDisplay2(EquipmentObject b)
    {
        LarmorSprite.SetActive(false);
        HarmorSprite.SetActive(false);
        if (b.equipmentType == eqType.heavyArmor)
        {
            HarmorSprite.SetActive(true);

            
        }
        else if (b.equipmentType == eqType.lightArmor)
        {
            LarmorSprite.SetActive(true);

            
        }

    }
    public void destroyAsset()
    {
        if (assetsSpawned != null)
        {
            Destroy(assetsSpawned);
        }
    }
}
