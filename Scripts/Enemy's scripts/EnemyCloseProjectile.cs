using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloseProjectile : MonoBehaviour
{
    public float Damage;

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.tag != "Enemy" && Collision.tag != "Projectile")
        {
            if (Collision.tag == "Player")
            {
                PlayerSetts.playerStats.DealDamage(Damage);
            }
        }
    }
}
