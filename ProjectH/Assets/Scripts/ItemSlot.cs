using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Text nameItem;
    public Text costItem;
    public Item item;

    public void Update()
    {
        if (item != null)
        {
            nameItem.text = item.nameItem;
            costItem.text = item.cost + "";
        }
    }
}
