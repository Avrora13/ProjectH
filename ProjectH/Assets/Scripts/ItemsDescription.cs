using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsDescription : MonoBehaviour
{
    public Text nameItem;
    public Text descriptionItem;
    public Text costItem;
    public Item item;
    public Player player;

    public void Use()
    {
        if (item.Type == Item.typeItem.Food)
        {
            Eat();
        }
        item.count--;
        for (int i = 0;i < player.inventory.items.Count; i++)
        {
            if(player.inventory.items[i].id == item.id)
            {
                if(player.inventory.items[i].count == 0)
                {
                    player.inventory.items.RemoveAt(i);
                }
            }
        }
    }

    private void Eat()
    {
        player.hunger += item.regnHug;
    }
}
