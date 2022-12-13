using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelmFunction : PutOnFunction
{
    public GameObject Helm;    

    public override void UseItem()
    {
        GameObject head = GameObject.Find("Head");
        GameObject game_manager = GameObject.Find("Game Manager");
        
        head.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
        head.GetComponent<PersonButton>().item = Helm;

        game_manager.GetComponent<PlayerSetts>().ChangeArmor(GetComponent<HelmScript>().armor);
    }

    public override void UnUseItem()
    {
        GameObject head = GameObject.Find("Head");
        GameObject gameManager = GameObject.Find("Game Manager");

        head.GetComponent<Image>().sprite = Resources.Load("ButtonBG", typeof(Sprite)) as Sprite;
        head.GetComponent<PersonButton>().item = null;
        ItemTrigger itemTriger = GetComponent<ItemTrigger>();
        head.GetComponent<PersonButton>().cam.GetComponent<Inventory>().SearchForSameItem(itemTriger.data.items[itemTriger.itemID], 1);
        gameManager.GetComponent<PlayerSetts>().ChangeArmor(-GetComponent<HelmScript>().armor);
    }
}
