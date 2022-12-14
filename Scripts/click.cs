using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class click : MonoBehaviour, IPointerClickHandler
{
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    Transform object_pos;
    Collider2D Collision;

    public Transform player_pos;

    public Sprite Open;
    public Sprite Close;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        object_pos = GetComponent<Transform>();
        Collision = GetComponent<Collider2D>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        double size_obj_play = Mathf.Sqrt((player_pos.position.x - object_pos.position.x) * (player_pos.position.x - object_pos.position.x) +
                                     (player_pos.position.y - object_pos.position.y) * (player_pos.position.y - object_pos.position.y));
        if (0.9f < size_obj_play && size_obj_play < 1.8f)
        {

            if (boxCollider2D.isTrigger == false)
            {
                Debug.Log("Open**");
                boxCollider2D.isTrigger = true;
                spriteRenderer.sprite = Open;
                Collision.tag = "Open_door";
            }
            else
            {
                Debug.Log("Close**");
                boxCollider2D.isTrigger = false;
                spriteRenderer.sprite = Close;
                Collision.tag = "buildings";
            }
        }
    }

 
}
