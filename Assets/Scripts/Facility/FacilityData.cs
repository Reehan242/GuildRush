using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Facility Data", menuName = "Guild Rush/Facility Data")]
public class FacilityData : ScriptableObject
{
    public int facilityID;
    public string facilityName;
    public string facilityDescription;
    public int Level;
    public int UnlockRank;
    public int maxLevel;
    public int[] upgradeCost;
}