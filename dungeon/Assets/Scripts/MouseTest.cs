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
        //OnMouseOver();
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
        
        if(isMouseOver)
        {
            Debug.Log("help");
            if (Input.GetMouseButtonDown(1))
            {

                if (item != null)
                {
                    if (item.GetComponent<ItemFunction>() != null)
                    {
                        item.GetComponent<ItemFunction>().UseItem();
                        GameObject.Find("Main Camera").GetComponent<Inventory>().items[ID].count--;
                        GameObject.Find("Main Camera").GetComponent<Inventory>().UpdateInventory();
                    }
                }
            }
        }
    }
}
