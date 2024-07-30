using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popup;

    void Start()
    {
        PopupOff();
    }

    public void PopupOff()
    {
        popup.transform.localScale = Vector3.zero;
    }
}