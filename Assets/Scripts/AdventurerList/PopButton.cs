using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PopButton : MonoBehaviour
{
    public GameObject popup;
    public Adventurerdetails adventurerDetails;
    private int adventurerIdx;

    private void Start()
    {
        adventurerDetails = FindObjectOfType<Adventurerdetails>();
    }

    public void SetAdventurerIdx(int idx)
    {
        adventurerIdx = idx;
    }

    public void PopupOn()
    {
        popup = GameObject.Find("PopUp");

        if (popup != null && adventurerDetails != null)
        {
            popup.transform.localScale = new Vector3(1f, 1f, 1f);
            adventurerDetails.SetSelectedAdventurerIdx(adventurerIdx);
            adventurerDetails.UpdateDetailsBasedOnIndex(adventurerIdx);
        }
        else Debug.LogError("Popup object or Adventurerdetails not found.");
    }
}
