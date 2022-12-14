using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordFunction : PutOnFunction
{
    public GameObject projectile;
    public GameObject particle;
    public GameObject Sword;
    public float projectile_distance;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public GameObject game_manager;

    public GameObject player;

    public override void UseItem()
    {
        player = GameObject.Find("Player");
        PutPicture("Right arm", Sword);
        player.GetComponent<close_damage>().Attack -= player.GetComponent<close_damage>().StandartAttack;
        player.GetComponent<close_damage>().Attack += NewAttack;
        game_manager = GameObject.Find("Game Manager");
    }

    public override void UnUseItem()
    {
        TakeOffPicture("Right arm");
        player.GetComponent<close_damage>().Attack -= NewAttack;
        player.GetComponent<close_damage>().Attack += player.GetComponent<close_damage>().StandartAttack;
    }

    void NewAttack()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = player.GetComponent<Transform>().transform.position;

        Vector3 hit_test = transform.eulerAngles;

        hit_test.z = Mathf.Atan((mousePos.y - myPos.y) / (mousePos.x - myPos.x)) * Mathf.Rad2Deg;

        Vector3 direction = (mousePos - myPos).normalized;

        GameObject Particle = Instantiate(particle, player.GetComponent<Transform>().transform.position + direction * projectileForce, Quaternion.identity);
        GameObject Hit = Instantiate(projectile, player.GetComponent<Transform>().transform.position + direction * projectileForce, Quaternion.identity);
        Hit.GetComponent<ExplosionDealDamage>().Damage = UnityEngine.Random.Range(minDamage, maxDamage) * game_manager.GetComponent<PlayerSetts>().GetDamageMultiplier();

    }
}
