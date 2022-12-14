using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move_object : MonoBehaviour
{
    bool Direction = true;
    public Vector2 moveVector;
    public float speed = 3f;
    public Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public Animator anim;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        walk();
    }

    void walk() {
        moveVector.x = Input.GetAxis("Horizontal");
        if (moveVector.x == 0)
        {
            anim.SetFloat("Sp", 0);
        }
        else
        {
            anim.SetFloat("Sp", 1);
        }

        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        

        moveVector.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveVector.y * speed);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos = transform.position;

        //if (mousePos.x - myPos.x > 0) spriteRenderer.flipX = false;
        //else spriteRenderer.flipX = true;

        if (moveVector.x >= 0 && Direction == false) {
            Flip();
        }
        else if (moveVector.x < 0 && Direction == true) {
            Flip(); 
        }
    }

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
    //    return true;
    //}

    private void Flip()
    {
        Direction = !Direction;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        return;
    }
}
