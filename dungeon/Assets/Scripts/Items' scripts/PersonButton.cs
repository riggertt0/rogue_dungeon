using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonButton : MonoBehaviour
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
            if (Input.GetMouseButtonDown(1))
            {

                if (item != null)
                {
                    if (item.GetComponent<ItemFunction>() != null)
                    {
                        item.GetComponent<ItemFunction>().UnUseItem();
                        cam.GetComponent<Inventory>().UpdateInventory();
                    }
                }
            }
        }
    }
}
