using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_object : MonoBehaviour
{
    public Vector2 moveVector;
    public float speed = 3f;
    public Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        if (walk())
        {
           // Debug.Log("Move*");
        }
        else {
            //Debug.Log("Stay*");
        }
    }

    bool walk() {
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        

        moveVector.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveVector.y * speed);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;

        if (mousePos.x - myPos.x > 0) spriteRenderer.flipX = false;
        else spriteRenderer.flipX = true;

        /*if (moveVector.x > 0)
        {
            spriteRenderer.flipX = false;   
        }
        if (moveVector.x < 0)
        {
            spriteRenderer.flipX = true;    
        }
        if (moveVector.x > 0.1 || moveVector.x < -0.1 || moveVector.y > 0.1 || moveVector.y < -0.1) return true;

        return false;*/
        return true;
    }
}
