using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMoving : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float distance;
    private List<ItemInventory> items;

    void Start()
    {
        player = GameObject.Find("Player");
        items = GameObject.Find("Main Camera").GetComponent<Inventory>().items;
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 playerPos = player.transform.position;
            Vector2 coinPos = transform.position;
            if (Vector2.Distance(playerPos, coinPos) < distance)
            {
                int occupiedCells = 0;

                bool NoMaxInstances = false;
                foreach (ItemInventory item in items)
                {
                    if (item.id == 0)
                        occupiedCells++;
                    if(item.id == GetComponent<ItemTrigger>().itemID && item.combination && item.count < 4)
                    {
                        NoMaxInstances = true;
                        break;
                    }
                }
                if(occupiedCells > 0 || NoMaxInstances)
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
