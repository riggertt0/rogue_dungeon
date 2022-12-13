using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutOnFunction : ItemFunction
{
    public void PutPicture(string cellName, GameObject obj)
    {
        GameObject cell = GameObject.Find(cellName);
        cell.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
        cell.GetComponent<PersonButton>().item = obj;
    }

    public void TakeOffPicture(string cellName)
    {
        GameObject cell = GameObject.Find(cellName);
        cell.GetComponent<Image>().sprite = Resources.Load("ButtonBG", typeof(Sprite)) as Sprite;
        cell.GetComponent<PersonButton>().item = null;
        ItemTrigger itemTriger = GetComponent<ItemTrigger>();
        cell.GetComponent<PersonButton>().cam.GetComponent<Inventory>().SearchForSameItem(itemTriger.data.items[itemTriger.itemID], 1);
    }
}
