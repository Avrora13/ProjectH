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
    [Min(0)]
    public int count;
    public typeItem Type;
    [TextArea(2, 8)]
    public string description;
    public enum typeItem
    {
        Weapon,
        Food,
        Heal
    }
    [HideInInspector]
    public float regnHug;
    [HideInInspector]
    public float damage;
}
