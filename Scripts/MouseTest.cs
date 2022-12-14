using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseTest : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public GameObject cam;

    private bool isMouseOver = false;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    void OnMouseEnter()
    {
        isMouseOver = true;
    }

    void OnMouseExit()
    {
        isMouseOver = false;
    }

    void Update()
    {
        if (isMouseOver)
        {
            //UnityEngine.Debug.Log("some text");
            if (Input.GetMouseButtonDown(1))
            {

                if (item != null)
                {
                    if (item.GetComponent<ItemFunction>() != null)
                    {
                        item.GetComponent<ItemFunction>().UseItem();
                        cam.GetComponent<Inventory>().items[ID].count--;
                        cam.GetComponent<Inventory>().UpdateInventory();
                    }
                }
            }
        }
    }
}
