using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_projectile : MonoBehaviour
{
    public float Damage;

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.tag != "Player" && Collision.tag != "Projectile" && Collision.tag != "Open_door")
        {
            if (Collision.GetComponent<EnemyReceiveDamage>() != null)
            {
                Collision.GetComponent<EnemyReceiveDamage>().DealDamage(Damage);
            }
        }
    }
}
