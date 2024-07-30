using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class FacilityButton : MonoBehaviour
{
    public FacilityData facilityData;

    public TMP_Text facilityLevel;





    // Start is called before the first frame update

    public void initialize(int Level)
    {

        facilityLevel.text = Level.ToString();
    }

    public void UpgradeFacility()
    {

        TestDataStats testDataStats = FindAnyObjectByType<TestDataStats>();

        testDataStats.UpgradeFacility(facilityData, this);
    }
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
