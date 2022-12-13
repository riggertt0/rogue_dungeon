using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordFunction : PutOnFunction
{
    public GameObject Sword;

    public override void UseItem()
    {
        GameObject player = GameObject.Find("Player");
        PutPicture("Right arm", Sword);
        player.GetComponent<close_damage>().Attack -= player.GetComponent<close_damage>().StandartAttack;
        player.GetComponent<close_damage>().Attack += Fuck;
    }

    public override void UnUseItem()
    {
        GameObject player = GameObject.Find("Player");
        TakeOffPicture("Right arm");
        player.GetComponent<close_damage>().Attack -= Fuck;
        player.GetComponent<close_damage>().Attack += player.GetComponent<close_damage>().StandartAttack;
    }

    void Fuck()
    {
        Debug.Log("Suck");
    }
}
