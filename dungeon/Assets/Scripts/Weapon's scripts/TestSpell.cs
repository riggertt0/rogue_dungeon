using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject projectile;

    public float minDamage;

    public float maxDamage;

    public float projectileForce;

    public float projectile_distance;

    public float cooldownTime;

    private float nextFireTime = 0f;

    void Start()
    {
        nextFireTime = Time.time;
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (!Inventory.isOpenInventory)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    nextFireTime = Time.time + cooldownTime;
                    GameObject Spell = Instantiate(projectile, transform.position, Quaternion.identity);

                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 myPos = transform.position;
                    Spell.GetComponent<distance_spell>().start_pos = myPos;
                    Spell.GetComponent<distance_spell>().distance = projectile_distance;

                    Vector3 spell_test = transform.eulerAngles;

                    spell_test.z = Mathf.Atan((mousePos.y - myPos.y) / (mousePos.x - myPos.x)) * Mathf.Rad2Deg;

                    if (mousePos.x - myPos.x < 0)
                    {
                        Spell.GetComponent<SpriteRenderer>().flipX = true;
                        Spell.GetComponent<Collider2D>().offset *= -1;
                    }
                    Spell.GetComponent<Transform>().eulerAngles = spell_test;

                    Vector2 direction = (mousePos - myPos).normalized;

                    Spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                    Spell.GetComponent<TestProjectile>().Damage = Random.Range(minDamage, maxDamage);
                }
            }
        }
    }
}
