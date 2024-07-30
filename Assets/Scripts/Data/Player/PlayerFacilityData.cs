using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class PlayerFacilityData
{
    public Dictionary<int, int> playerFacilities = new Dictionary<int, int>();
    public void UnlockFacility(int facilityID, int level)
    {
        if (!playerFacilities.ContainsKey(facilityID)) //check facility jika belum dimiliki pemain
        {
            playerFacilities.Add(facilityID, level);
        }
        else
        {
            Debug.LogWarning("Fasilitas sudah dimiliki oleh pemain.");
        }
    }
    public void UpgradeFacility(int facilityID)
    {

        if (playerFacilities.ContainsKey(facilityID))
        {
            playerFacilities[facilityID]++; // Menambah tingkat fasilitas
        }
        else
        {
            UnlockFacility(facilityID, 0);
            Debug.LogWarning("Fasilitas belum dibuka.");
        }
    }

    public int GetFacilityLevel(int facilityID)
    {
        if (playerFacilities.ContainsKey(facilityID))
        {
            return playerFacilities[facilityID];
        }
        else
        {
            Debug.LogWarning("Fasilitas tidak ditemukan atau belum dibuka oleh pemain.");
            return 0;
        }
    }

}