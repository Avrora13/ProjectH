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
    }

    private void Eat()
    {
        player.hunger += item.regnHug;
    }
}
