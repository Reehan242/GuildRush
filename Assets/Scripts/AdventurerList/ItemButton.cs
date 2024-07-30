using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System;

[System.Serializable]
public class ItemButtonEvent : UnityEvent<ItemButton>
{

}
public class ItemButton : MonoBehaviour/*, ISelectHandler, IPointerClickHandler, ISubmitHandler*/
{
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemRank;
    [SerializeField] private TMP_Text itemClass;
    [SerializeField] private TMP_Text itemAtk;
    [SerializeField] private TMP_Text itemDef;
    [SerializeField] private TMP_Text itemSpd;
    [SerializeField] private TMP_Text itemTrait;
    [SerializeField] private Image itemCard;
    [SerializeField] private Sprite cardSSS;
    [SerializeField] private Sprite cardSS;
    [SerializeField] private Sprite cardS;
    [SerializeField] private Sprite cardA;
    [SerializeField] private Sprite cardB;
    [SerializeField] private Sprite cardC;
    [SerializeField] private Sprite cardD;
    [SerializeField] private Sprite cardE;
    [SerializeField] private Sprite cardF;
    [SerializeField] private RawImage modelViewer;
    public int adventurerIdx;
    //[SerializeField] private Sprite rankCard;
    //[SerializeField] private ItemButtonEvent onSelectEvent;
    //[SerializeField] private ItemButtonEvent onSubmitEvent;
    //[SerializeField] private ItemButtonEvent onClickEvent;
    //public ItemButtonEvent OnSelectEvent { get => onSelectEvent; set => onSelectEvent = value; }
    //public ItemButtonEvent OnSubmitEvent { get => onSubmitEvent; set => onSubmitEvent = value; }
    //public ItemButtonEvent OnClickEvent { get => onClickEvent; set => onClickEvent = value; }
    public string ItemNameValue { get => itemName.text; set => itemName.text = value; }
    public string ItemRankValue { get => itemRank.text; set => itemRank.text = value; }
    public string ItemClassValue { get => itemClass.text; set => itemClass.text = value; }
    public string ItemTraitValue { get => itemTrait.text; set => itemTrait.text = value; }
    public string ItemAtkValue { get => itemAtk.text; set => itemAtk.text = value; }
    public string ItemDefValue { get => itemDef.text; set => itemDef.text = value; }
    public string ItemSpdValue { get => itemSpd.text; set => itemSpd.text = value; }

    public Texture modelValue { get => modelViewer.texture; set => modelViewer.texture = value; }
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    OnClickEvent.Invoke(this);
    //}

    //public void OnSelect(BaseEventData eventData)
    //{
    //    OnSelectEvent.Invoke(this);
    //}

    //public void OnSubmit(BaseEventData eventData)
    //{
    //    OnSubmitEvent.Invoke(this);
    //}

    //public void ObtainSelectionFocus()
    //{
    //    EventSystem.current.SetSelectedGameObject(this.gameObject);
    //    OnSelectEvent.Invoke(this);
    //}

    internal void SetItemImage(string rank)
    {
        switch (rank)
        {
            case "SSS":
                itemCard.sprite = cardSSS;
                break;
            case "SS":
                itemCard.sprite = cardSS;
                break;
            case "S":
                itemCard.sprite = cardS;
                break;
            case "A":
                itemCard.sprite = cardA;
                break;
            case "B":
                itemCard.sprite = cardB;
                break;
            case "C":
                itemCard.sprite = cardC;
                break;
            case "D":
                itemCard.sprite = cardD;
                break;
            case "E":
                itemCard.sprite = cardE;
                break;
            case "F":
                itemCard.sprite = cardF;
                break;
            default:
                Debug.LogError("Invalid rank: " + rank);
                break;
        }
    }
}