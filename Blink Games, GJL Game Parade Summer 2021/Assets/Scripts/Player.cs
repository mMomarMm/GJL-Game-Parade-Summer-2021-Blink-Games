using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float vertical, horizontal;
    public float runSpeed, JumpForce, DownForce;
    Rigidbody2D rb;
    public Vector2 crouchSize;
    public GameObject sprite;
    Vector3 Scale, ogSize;
    bool Grounded;
    public BoxCollider2D BodyCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Scale = sprite.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMov();
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Grounded)
        {
            //jump
            if (vertical != 0)
            {
                if (vertical == -1) Crouch();
                else
                {
                    Stand();
                    Grounded = false;
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Stand();
                Grounded = false;
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -DownForce);
        }
    }
    void HorizontalMov()
    {
        rb.velocity = new Vector2(runSpeed * horizontal, rb.velocity.y);
        Scale.x = horizontal;
        if (horizontal != 0) sprite.transform.localScale = Scale;
    }
    void Crouch()
    {
        //Crouch animation
        //maybe sound
        BodyCollider.size = crouchSize;
        BodyCollider.offset = new Vector2(.1f, -0.4f);
    }
    void Stand()
    {
        //Stand animation
        //maybe sound
        BodyCollider.size = ogSize;
        BodyCollider.offset = Vector2.zero;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) Grounded = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) Grounded = false;
    }
}