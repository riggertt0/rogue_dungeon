using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float Damage;

    void OnTriggerEnter2D(Collider2D Collision)
    {
        
        if (Collision.tag != "Enemy" && Collision.tag != "Projectile" && Collision.tag != "Level")
        {
            if (Collision.tag == "Player")
            {
                PlayerSetts.playerStats.DealDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
}
