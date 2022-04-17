using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject player;
    public float distanceDialog;
    public float currentDistant;
    public GameObject dialogUI;
    public string nameNPC;
    public List<Item> inventoryNpc;

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        currentDistant = distance;
        if(currentDistant <= distanceDialog && Input.GetKeyDown(KeyCode.E))
        {
            dialogUI.SetActive(true);
            dialogUI.GetComponent<dialogUI>().namenpcID = nameNPC;
        }
        if (currentDistant > distanceDialog && dialogUI.activeSelf == true)
        {
            dialogUI.SetActive(false);
        }
    }
}
