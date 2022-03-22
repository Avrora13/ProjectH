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
    public GameObject playerObject;
    public GameObject DropObject;

    public void Use()
    {
        if (item.Type == Item.typeItem.Food)
        {
            Eat();
        }
        else if (item.Type == Item.typeItem.Weapon)
        {
            UseWeapon();
        }
    }

    public void DropItem()
    {
        GameObject NewObject = Instantiate<GameObject>(DropObject, new Vector3(playerObject.gameObject.transform.position.x + 5, playerObject.gameObject.transform.position.y, playerObject.gameObject.transform.position.z), Quaternion.identity) as GameObject;
        NewObject.GetComponent<ItemTake>().item = item;
        NewObject.SetActive(true);
        item.count--;
        for (int i = 0; i < player.inventory.items.Count; i++)
        {
            if (player.inventory.items[i].id == item.id)
            {
                if (player.inventory.items[i].count == 0)
                {
                    player.inventory.items.RemoveAt(i);
                }
            }
        }
    }

    private void Eat()
    {
        player.hunger += item.regnHug;
        item.count--;
        for (int i = 0; i < player.inventory.items.Count; i++)
        {
            if (player.inventory.items[i].id == item.id)
            {
                if (player.inventory.items[i].count == 0)
                {
                    player.inventory.items.RemoveAt(i);
                }
            }
        }
    }

    private void UseWeapon()
    {
        player.Weapon = item;
        player.inventory.nameWeapon.text = item.nameItem;
    }
}
