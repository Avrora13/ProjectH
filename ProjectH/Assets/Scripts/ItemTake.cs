using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTake : MonoBehaviour
{
    public Item item;
    public GameObject Slot;
    public GameObject canvas;
    public Inventory inventory;

    public void TakeItem()
    {
        if(inventory.items.Count != 0)
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                if(inventory.items[i].id == item.id)
                {
                    inventory.items[i].count++;
                    Destroy(this.gameObject);
                    break;
                }
                else if (inventory.items[i] == inventory.items[(inventory.items.Count - 1)])
                {
                    GameObject NewItem = Instantiate<GameObject>(Slot, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    NewItem.transform.SetParent(canvas.transform, false);
                    NewItem.GetComponent<ItemSlot>().item = item;
                    inventory.items.Add(item);
                    inventory.items[(inventory.items.Count - 1)].count++;
                    NewItem.SetActive(true);
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            GameObject NewItem = Instantiate<GameObject>(Slot, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            NewItem.transform.SetParent(canvas.transform, false);
            NewItem.GetComponent<ItemSlot>().item = item;
            inventory.items.Add(item);
            inventory.items[(inventory.items.Count - 1)].count++;
            NewItem.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TakeItem();
    }
}
