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

    void Start()
    {
        cam = GameObject.Find("Main Camera");
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
                cam.GetComponent<Inventory>().SearchForSameItem(data.items[itemID], 1);
                Destroy(gameObject);
        }
    }
}
