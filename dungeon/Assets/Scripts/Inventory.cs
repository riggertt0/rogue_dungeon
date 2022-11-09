using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public DataBase data;

    public List<ItemInventory> items = new List<ItemInventory>();

    public GameObject gameObjShow;

    public GameObject InventoryMainObject;
    public int maxCount;

    public Camera cam;
    public EventSystem es;

    public int currentID;
    public ItemInventory currentItem;

    public RectTransform movingObject;
    public Vector3 offset;

    public GameObject backGround;

    
    public void Start()
    {
        if(items.Count == 0)
        {
            AddGraphics();
        }

        backGround.SetActive(false);
        UpdateInventory();

    }

    public void Update() 
    {
        if(currentID != -1)
        {
            MoveObject();
        }

        if(Input.GetKeyDown(KeyCode.E) && currentID == -1 && !GameObject.Find("Menu"))
        {
            backGround.SetActive(!backGround.activeSelf);
            if(backGround.activeSelf)
            {
                UpdateInventory();
            }
            if(!backGround.activeSelf && !GameObject.Find("Menu"))
                Time.timeScale = 1f;
            else
                Time.timeScale = 0f;
        }
    }

    public void SearchForSameItem(Item item, int count)
    {
        if (item.combination == true)
        {
            for (int i = 0; i < maxCount; ++i)
            {
                if (items[i].id == item.id)
                {
                    if (items[i].count < 128)
                    {
                        items[i].count += count;

                        if (items[i].count > 128)
                        {
                            count = items[i].count - 128;
                            items[i].count = 128;
                        }
                        else
                        {
                            count = 0;
                            i = maxCount;
                        }
                    }
                }
            }
        }

        

        if (count > 0)
        {
            for(int i = 0; i < maxCount; ++i)
            {
                if(items[i].id == 0)
                {
                    AddItem(i, item, count);
                    i = maxCount;
                }
            }
        }
        UpdateInventory();

    }

    public void AddItem(int id, Item item, int count)
    {
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObj.GetComponent<Image>().sprite = item.img;
        items[id].itemGameObj.GetComponent<MouseTest>().item = null;
        items[id].combination = item.combination;

        if (items[id].combination == false) items[id].count = 1;

        if (count > 1 && item.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();
        }
        else 
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }

    //public void RemoveItem(int 


    public void AddInventoryItem(int id, ItemInventory invItem)
    {
        items[id].id = invItem.id;
        items[id].count = invItem.count;
        items[id].itemGameObj.GetComponent<Image>().sprite = data.items[invItem.id].img;
        items[id].itemGameObj.GetComponent<MouseTest>().item = data.items[invItem.id].item;
        items[id].combination = invItem.combination;

        if (invItem.count > 1 && invItem.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = invItem.count.ToString();
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }



    public void AddGraphics() 
    {
        for (int i = 0; i < maxCount; ++i) 
        {
            GameObject newItem = Instantiate(gameObjShow, InventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();

            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;

            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1, 1);

            Button tempButton = newItem.GetComponent<Button>();

            tempButton.onClick.AddListener(delegate { SelectObject(); });

            items.Add(ii);
        }
    }

    public void UpdateInventory()
    { 
        for(int i = 0; i < maxCount; ++i)
        {
            if(items[i].id != 0 && items[i].count > 1)
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = "";
            }

            if (items[i].count > 0)
            {
                items[i].itemGameObj.GetComponent<Image>().sprite = data.items[items[i].id].img;
                items[i].itemGameObj.GetComponent<MouseTest>().item = data.items[items[i].id].item;
                items[i].itemGameObj.GetComponent<MouseTest>().ID = i;
            }
            else
            {
                items[i].itemGameObj.GetComponent<Image>().sprite = null;
                items[i].itemGameObj.GetComponent<MouseTest>().item = null;
                items[i].itemGameObj.GetComponent<MouseTest>().ID = i;
                items[i].id = 0;
            }
        }
    }

    public void SelectObject()
    {
        if(currentID == -1)
        {
            if (items[int.Parse(es.currentSelectedGameObject.name)].id == 0)
            {
                return;
            }
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = data.items[currentItem.id].img;

            AddItem(currentID, data.items[0], 0);
        }
        else
        {
            ItemInventory II = items[int.Parse(es.currentSelectedGameObject.name)];

            if (currentItem.id != II.id || currentItem.combination == false)
            {
                AddInventoryItem(currentID, II);

                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
            }
            else
            {
                if(II.count + currentItem.count <= 128)
                {
                    II.count += currentItem.count;
                }
                else
                {
                    AddItem(currentID, data.items[II.id], II.count + currentItem.count - 128);

                    II.count = 128;
                }

                II.itemGameObj.GetComponentInChildren<Text>().text = II.count.ToString();

            }
            currentID = -1;

            movingObject.gameObject.SetActive(false);
        }
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = InventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }

    public ItemInventory CopyInventoryItem(ItemInventory old)
    {
        ItemInventory New = new ItemInventory();

        New.id = old.id;
        New.itemGameObj = old.itemGameObj;
        New.count = old.count;
        New.combination = old.combination;

        return New;
    }
}

[System.Serializable]

public class ItemInventory
{
    public int id;
    public GameObject itemGameObj;

    public int count;

    public bool combination;

    public GameObject item_button;
}