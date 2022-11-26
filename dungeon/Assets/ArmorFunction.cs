using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ArmorFunction : ItemFunction
{
    public GameObject Armor;
    public bool isUsed;

    public void Start()
    {
        isUsed = true;
    }

    public override void UseItem()
    {
        GameObject body = GameObject.Find("Body");
        GameObject game_manager = GameObject.Find("Game Manager");
        if (!isUsed)
        {
            
            body.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
            body.GetComponent<PersonButton>().item = Armor;

            game_manager.GetComponent<PlayerSetts>().ChangeArmor(GetComponent<ArmorScript>().armor);
            isUsed = true;
        } else
        {
            body.GetComponent<Image>().sprite = Resources.Load("ButtonBG", typeof(Sprite)) as Sprite;
            body.GetComponent<PersonButton>().item = null;
            ItemTrigger item_triger = GetComponent<ItemTrigger>();
            body.GetComponent<PersonButton>().cam.GetComponent<Inventory>().SearchForSameItem(item_triger.data.items[item_triger.itemID], 1);


            game_manager.GetComponent<PlayerSetts>().ChangeArmor(-GetComponent<ArmorScript>().armor);
            isUsed = false;
        }
    }
}
