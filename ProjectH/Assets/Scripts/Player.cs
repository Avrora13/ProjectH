using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0f, 100f)]
    public float hp;
    [Range(0f, 100f)]
    public float hunger;
    public float hungerSpeed;
    public Inventory inventory;

    public void FixedUpdate()
    {
        inventory.hpBar.value = (hp / 100);
        hunger -= Time.deltaTime * hungerSpeed;
        inventory.hungerBar.value = (hunger / 100);
        if (hunger > 100)
        {
            hunger = 100;
        }
    }
}
