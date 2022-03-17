using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Text nameItem;
    public Text costItem;
    public Item item;
    public GameObject itemDescription;

    public void Update()
    {
        if (item != null)
        {
            nameItem.text = item.nameItem;
            costItem.text = item.count + "";
            if (item.count == 0)
            {
                item = null;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowDescription()
    {
        ItemsDescription description = itemDescription.GetComponent<ItemsDescription>();
        description.nameItem.text = item.nameItem;
        description.descriptionItem.text = item.description;
        description.costItem.text = "Cost: " + item.cost;
        description.item = item;
        itemDescription.SetActive(true);
    }
}
