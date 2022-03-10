using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Objects/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string nameItem;
    public Sprite spriteItem;
    public int cost;
    public typeItem Type;
    public enum typeItem
    {
        Weapon,
        Food,
        Heal
    }
}
