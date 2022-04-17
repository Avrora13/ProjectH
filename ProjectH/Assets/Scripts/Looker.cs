using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour
{
    public GameObject enemy;
    private float reset = 5;
    private bool movingDown;

    void Update()
    {
        if (movingDown == false)
        {
            transform.position -= new Vector3(0, 0, 0.1f);
        }
        else
        {
            transform.position += new Vector3(0, 0, 0.1f);
        }
        if(transform.position.z > 10)
        {
            movingDown = false;
        }
        else if(transform.position.z < -10)
        {
            movingDown = true;
        }
        reset -= Time.deltaTime;
        if (reset < 0)
        {
            enemy.GetComponent<Enemy>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.GetComponent<Enemy>().enabled = true;
            reset = 5;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
