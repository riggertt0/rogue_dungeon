using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelmFunction : ItemFunction
{
    public override void UseItem()
    {
        GameObject.Find("Head").GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
    }
}
