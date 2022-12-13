using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class TestEnemyShooting : MonoBehaviour
{
    public GameObject projectile;

    private GameObject player;

    public float minDamage;

    public float maxDamage;

    public float dist;

    public float projectileForce;

    public float cooldown;

    private AgentScript _agentScript;

    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<move_object>().gameObject;
        _agentScript = gameObject.GetComponent<AgentScript>();
    }

    private void Update()
    {
        if (player != null && _agentScript.aggre == true &&
            _agentScript.isOnLine)
        {
         
            _agentScript.agent.isStopped = true;
            //gameObject.GetComponent<AgentScript>().agent.SetDestination(player.transform.position);   
        }
        else
        {
            _agentScript.agent.isStopped = false;
            _agentScript.agent.SetDestination(player.transform.position);
        }
    }

    IEnumerator ShootPlayer()
    {

        yield return new WaitForSeconds(cooldown);
        
        
        Vector2 playerPos = player.transform.position;
        Vector2 myPos = transform.position;

        if (player != null && _agentScript.aggre == true && _agentScript.isOnLine
            && dist > Vector2.Distance(myPos, playerPos))
        {
            
            GameObject Spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 direction = (playerPos - myPos).normalized;

            Vector3 spell_test = transform.eulerAngles;

            spell_test.z = Mathf.Atan((playerPos.y - myPos.y) / (playerPos.x - myPos.x)) * Mathf.Rad2Deg;

            if (playerPos.x - myPos.x < 0) Spell.GetComponent<SpriteRenderer>().flipX = true;
            Spell.GetComponent<Transform>().eulerAngles = spell_test;

            Spell.GetComponent<distance_spell>().start_pos = myPos;
            Spell.GetComponent<distance_spell>().distance = dist;

            //Debug.Log(Mathf.Atan((playerPos.y - myPos.y) / (playerPos.x - myPos.x)) * Mathf.Rad2Deg);
            //Debug.Log((playerPos.y - myPos.y) / (playerPos.x - myPos.x));
            //Debug.Log(playerPos.x - myPos.x);

            Spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            Spell.GetComponent<TestEnemyProjectile>().Damage = Random.Range(minDamage, maxDamage);

            StartCoroutine(ShootPlayer());
        }
        else
        {
            StartCoroutine(ShootPlayer());
        }
    }
}
