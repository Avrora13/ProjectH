using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speeds = 1f;
    public float X;
    public float Y;
    public float Z;
    void Update()
    {
        X += Input.GetAxis("Mouse X") * speeds * Time.deltaTime;
        Y += Input.GetAxis("Mouse Y") * speeds * Time.deltaTime;
        if (Input.GetKey(KeyCode.Q))
            Z += 1f * speeds * Time.deltaTime;
        if (Input.GetKey(KeyCode.E))
            Z -= 1f * speeds * Time.deltaTime;

        transform.rotation = Quaternion.Euler(Y, X, Z);
    }
}
