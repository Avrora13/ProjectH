using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;

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
