using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotionFunction : ItemFunction
{
    public override void UseItem()
    {
        GameObject.Find("Game Manager").GetComponent<PlayerSetts>().HealCharacter(GetComponent<HealthPotionScript>().HealthValue);
    }
}
