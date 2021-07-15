using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float vertical, horizontal;
    public float runSpeed, JumpForce, DownForce;
    Rigidbody2D rb;
    Animator an;
    public Vector2 crouchSize, weaponCrouchPos;
    public GameObject sprite, weapon;
    Vector3 Scale, ogSize, weaponOgPos;
    bool Grounded;
    public BoxCollider2D BodyCollider;
    public static float dir; //looking direction

    void Start()
    {
        weaponOgPos = new Vector2(0, -0.36f);
        an = GetComponentInChildren<Animator>();
        ogSize = BodyCollider.size;
        rb = GetComponent<Rigidbody2D>();
        Scale = Vector3.one;
    }

    private void Update()
    {
        HorizontalMov();
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if (Grounded)
        {
            if (vertical == -1)
            {
                Crouch();
            }
            else
            {
                Stand();
                //jump
                if (vertical == 1 || Input.GetKeyDown(KeyCode.Space))
                {
                    an.SetBool("Jumping", true);
                    an.SetBool("Running", false);
                    Grounded = false;
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                }
            }
        }
        else
        {
            if (vertical == -1)
            {
                an.SetBool("Jumping", false);
                an.SetBool("StartGlide", true);
                an.SetBool("Gliding", true);
                rb.velocity = new Vector2(rb.velocity.x*.8f, -DownForce);
                StartCoroutine(wait());
            }
            else
            {
                an.SetBool("Gliding", false);
            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.21f);
        an.SetBool("StartGlide", false);
    }
    void HorizontalMov()
    {
        if (horizontal != 0)
        {
            an.SetBool("Running", true);
            rb.velocity = new Vector2(runSpeed * horizontal, rb.velocity.y);
            dir = horizontal;
            Scale.x = dir;
            transform.localScale = Scale;
        }
        else
        {
            an.SetBool("Running", false);
        }
    }
    public void Kill()
    {
        float i = 0;
        while (i < 6)
        {
            i += Time.deltaTime;
            if (i < 5)
            {
                an.SetFloat("IdleSpeed", 6);
            }
            else
            {
                an.SetFloat("IdleSpeed", 1);
            }
        }
    }

    void Crouch()
    {
        //maybe sound
        an.SetBool("Crouching", true);
        sprite.transform.localPosition = new Vector2(0, -0.4f);
        BodyCollider.size = crouchSize;
        BodyCollider.offset = new Vector2(0, -0.4f);
        weapon.transform.localPosition = weaponCrouchPos;
    }
    public void Stand()
    {
        //maybe sound
        an.SetBool("Crouching", false);
        sprite.transform.position = transform.position;
        BodyCollider.size = ogSize;
        BodyCollider.offset = Vector2.zero;
        weapon.transform.localPosition = weaponOgPos;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) Grounded = true; an.SetBool("Jumping", false); an.SetBool("Grounded", true); an.SetBool("Gliding", false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) Grounded = false; an.SetBool("Grounded", false); 
    }
}