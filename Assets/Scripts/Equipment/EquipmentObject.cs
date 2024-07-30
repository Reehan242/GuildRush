using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public int ID;
    public int uniqueID;
    public int level;
    public int hpBonus;
    public int atkBonus;
    public int defBonus;
    public int spdBonus;
    public string eqName;
    public eqType equipmentType;
    

}
public enum eqType
{
    sword,
    bow,
    shield,
    rod,
    book,
    heavyArmor,
    lightArmor
}