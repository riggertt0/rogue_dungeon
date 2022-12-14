using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseHit : MonoBehaviour
{
    public GameObject projectile;

    private GameObject player;

    public float minDamage;

    public float maxDamage;

    public float dist;

    public float projectileForce;

    public float cooldown;

    public Vector2 direction;

    void Start()
    {
        StartCoroutine(ShootPlayer());
        player = FindObjectOfType<move_object>().gameObject;
        direction = new Vector2(1, 0);
    }

    IEnumerator ShootPlayer()
    {

        yield return new WaitForSeconds(cooldown);

        if (player != null && gameObject.GetComponent<AgentScript>().aggre == true)
        {
            GameObject Spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 playerPos = player.transform.position;
            Vector2 myPos = transform.position;
            if (playerPos != myPos)
                direction = (playerPos - myPos).normalized;

            Vector3 spell_test = transform.eulerAngles;

            spell_test.z = Mathf.Atan((playerPos.y - myPos.y) / (playerPos.x - myPos.x)) * Mathf.Rad2Deg;

            if (playerPos.x - myPos.x < 0) Spell.GetComponent<SpriteRenderer>().flipX = true;
            Spell.GetComponent<Transform>().eulerAngles = spell_test;

            Spell.GetComponent<distance_spell>().start_pos = myPos;
            Spell.GetComponent<distance_spell>().distance = dist;

            Spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            Spell.GetComponent<EnemyCloseProjectile>().Damage = Random.Range(minDamage, maxDamage);

            StartCoroutine(ShootPlayer());
        }
        else
        {
            StartCoroutine(ShootPlayer());
        }
    }
}
