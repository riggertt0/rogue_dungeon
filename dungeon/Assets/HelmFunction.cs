using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelmFunction : ItemFunction
{
    public GameObject Helm;    

    public override void UseItem()
    {
        GameObject head = GameObject.Find("Head");
        GameObject game_manager = GameObject.Find("Game Manager");
        
        head.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
        head.GetComponent<PersonButton>().item = Helm;

        game_manager.GetComponent<PlayerSetts>().ChangeArmor(GetComponent<HelmScript>().armor);

        /*    head.GetComponent<Image>().sprite = Resources.Load("ButtonBG", typeof(Sprite)) as Sprite;
            head.GetComponent<PersonButton>().item = null;
            ItemTrigger item_triger = GetComponent<ItemTrigger>();
            head.GetComponent<PersonButton>().cam.GetComponent<Inventory>().SearchForSameItem(item_triger.data.items[item_triger.itemID], 1);


            game_manager.GetComponent<PlayerSetts>().ChangeArmor(-GetComponent<HelmScript>().armor);
            isUsed = false;*/

    }

    public override void UnUseItem()
    {
        GameObject head = GameObject.Find("Head");
        GameObject game_manager = GameObject.Find("Game Manager");

        head.GetComponent<Image>().sprite = Resources.Load("ButtonBG", typeof(Sprite)) as Sprite;
        head.GetComponent<PersonButton>().item = null;
        ItemTrigger item_triger = GetComponent<ItemTrigger>();
        head.GetComponent<PersonButton>().cam.GetComponent<Inventory>().SearchForSameItem(item_triger.data.items[item_triger.itemID], 1);


        game_manager.GetComponent<PlayerSetts>().ChangeArmor(-GetComponent<HelmScript>().armor);
    }
}
