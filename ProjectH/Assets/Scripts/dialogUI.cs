using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogUI : MonoBehaviour
{
    public TextMeshProUGUI nameNPC;
    public string namenpcID;

    void Start()
    {
        nameNPC.text = namenpcID;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
