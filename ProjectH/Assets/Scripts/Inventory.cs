using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public Slider hpBar;
    public Slider hungerBar;
    public Item[] items;
    public GameObject itemInInv;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(inventory.activeInHierarchy == true)
            {
                inventory.SetActive(false);
                Cursor.visible = false;
            }
            else
            {
                inventory.SetActive(true);
                Cursor.visible = true;
            }
        }

    }
}
