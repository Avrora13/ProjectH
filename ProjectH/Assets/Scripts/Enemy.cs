using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float hpEnemy = 100;
    public string nameEnemy;
    public GameObject nameObj;
    public GameObject player;
    public float DistanceToWalk;
    public float DistanceToHit;
    public float curDistance;
    public bool eWalk;
    public bool eHit;
    public float Hit;
    public float DelayBetweenAnim;
    public float speedAttack;
    UnityEngine.AI.NavMeshAgent _agent;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerWeapon")
        {
            hpEnemy -= other.GetComponent<Weapon>().damage;
        }
    }

    private void Start()
    {
        nameObj.GetComponent<TextMeshPro>().text = nameEnemy;
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        if(hpEnemy <= 0)
        {
            Destroy(gameObject);
        }
        float distance = Vector3.Distance(player.transform.position, transform.position);
        curDistance = distance;
        if (distance > DistanceToWalk)
        {
            return;
        }

        if (distance < DistanceToWalk && distance > DistanceToHit)
        {
            //Преследовать
            _agent.SetDestination(player.transform.position);
        }

        if (distance < DistanceToWalk && distance < DistanceToHit)
        {
            //Преследовать и кусать
            _agent.SetDestination(player.transform.position);
            transform.LookAt(player.transform);
            if (!eHit)
            {
                StartCoroutine(Mlee());
            }
        }
    }

    IEnumerator Mlee()
    {
        eHit = true;
        yield return new WaitForSeconds(speedAttack);
        player.GetComponent<Player>().hp -= Random.Range(0, Hit);
        yield return new WaitForSeconds(DelayBetweenAnim);
        eHit = false;
    }
}