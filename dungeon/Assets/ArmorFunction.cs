using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ArmorFunction : ItemFunction
{
    public GameObject Armor;

    public override void UseItem()
    {
        GameObject body = GameObject.Find("Body");
        GameObject game_manager = GameObject.Find("Game Manager");
        
        body.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
        body.GetComponent<PersonButton>().item = Armor;

        game_manager.GetComponent<PlayerSetts>().ChangeArmor(GetComponent<ArmorScript>().armor);
    }

    public override void UnUseItem()
    {
        GameObject body = GameObject.Find("Body");
        GameObject game_manager = GameObject.Find("Game Manager");
        body.GetComponent<Image>().sprite = Resources.Load("ButtonBG", typeof(Sprite)) as Sprite;
        body.GetComponent<PersonButton>().item = null;
        ItemTrigger item_triger = GetComponent<ItemTrigger>();
        body.GetComponent<PersonButton>().cam.GetComponent<Inventory>().SearchForSameItem(item_triger.data.items[item_triger.itemID], 1);


        game_manager.GetComponent<PlayerSetts>().ChangeArmor(-GetComponent<ArmorScript>().armor);
    }
}
