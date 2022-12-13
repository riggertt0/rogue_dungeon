using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyShooting : MonoBehaviour
{
    public GameObject projectile;

    private GameObject player;

    public float minDamage;

    public float maxDamage;

    public float dist;

    public float projectileForce;

    public float cooldown;

    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<move_object>().gameObject;
    }

    IEnumerator ShootPlayer()
    {

        yield return new WaitForSeconds(cooldown);

        if (player != null && gameObject.GetComponent<AgentScript>().aggre == true && gameObject.GetComponent<AgentScript>().isOnLine)
        {
            gameObject.GetComponent<AgentScript>().agent.isStopped = true;
            GameObject Spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 playerPos = player.transform.position;
            Vector2 myPos = transform.position;
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
            gameObject.GetComponent<AgentScript>().agent.isStopped = false;
            StartCoroutine(ShootPlayer());
        }
    }
}
