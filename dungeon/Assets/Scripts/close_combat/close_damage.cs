using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_damage : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;

    public float maxDamage;

    public float cooldownTime;

    public float projectileForce;

    public float projectile_distance;

    private float nextFireTime = 0f;

    public GameObject game_manager;

    public Action Attack;

    void Start()
    {
        nextFireTime = Time.time;
        Attack += StandartAttack;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime) {
            if (!Inventory.isOpenInventory)
            {
                if (Input.GetMouseButtonDown(0)) {
                    nextFireTime = Time.time + cooldownTime;
                    Attack.Invoke();
                }
            }
        }
            
    }

    public void StandartAttack()
    {
        GameObject Hit = Instantiate(projectile, transform.position, Quaternion.identity);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;
        Hit.GetComponent<distance_spell>().start_pos = myPos;
        Hit.GetComponent<distance_spell>().distance = projectile_distance;

        Vector3 hit_test = transform.eulerAngles;

        hit_test.z = Mathf.Atan((mousePos.y - myPos.y) / (mousePos.x - myPos.x)) * Mathf.Rad2Deg;

        if (mousePos.x - myPos.x < 0)
        {
            Hit.GetComponent<SpriteRenderer>().flipX = true;
            Hit.GetComponent<Collider2D>().offset *= -1;
        }
        Hit.GetComponent<Transform>().eulerAngles = hit_test;

        Vector2 direction = (mousePos - myPos).normalized;

        Hit.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
        Hit.GetComponent<close_projectile>().Damage = UnityEngine.Random.Range(minDamage, maxDamage) * game_manager.GetComponent<PlayerSetts>().GetDamageMultiplier();
    }
}
