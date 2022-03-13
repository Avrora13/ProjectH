using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float speed;
    float x;

    private void Update()
    {
        x += speed * Time.deltaTime;
        this.transform.rotation = Quaternion.Euler(x, 0, 0);
    }
}
