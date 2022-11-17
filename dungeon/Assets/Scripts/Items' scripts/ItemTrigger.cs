using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public GameObject cam;

    public GameObject item;
    public int itemID;
    public float distance;

    public bool death = false;

    public float death_discarding;

    public Vector2 start_pos;

    public DataBase data;

    public bool functionality;

    private List<ItemInventory> items;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        items = GameObject.Find("Main Camera").GetComponent<Inventory>().items;
    }

    void Update()
    {
        if (death == true)
        {
            if (Vector2.Distance(start_pos, item.GetComponent<Transform>().position) > death_discarding)
            {
                item.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int occupiedCells = 0;

            bool NoMaxInstances = false;
            foreach (ItemInventory item in items)
            {
                if (item.id == 0)
                    occupiedCells++;
                if (item.id == GetComponent<ItemTrigger>().itemID && item.combination && item.count < 4)
                {
                    NoMaxInstances = true;
                    break;
                }
            }
            if (occupiedCells > 0 || NoMaxInstances)
            {
                cam.GetComponent<Inventory>().SearchForSameItem(data.items[itemID], 1);
                cam.GetComponent<Inventory>().Update();
                Destroy(gameObject);
            }
        }
    }
}
