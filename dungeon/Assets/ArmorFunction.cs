using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorFunction : ItemFunction
{
    public override void UseItem()
    {
        GameObject.Find("Body").GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
    }
}
