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
    public static float dir;

    void Start()
    {
        weaponOgPos = new Vector2(0, -0.36f);
        an = GetComponentInChildren<Animator>();
        ogSize = BodyCollider.size;
        rb = GetComponent<Rigidbody2D>();
        Scale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMov();
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Grounded)
        {
            an.SetBool("Grounded", true);
            if (vertical == -1)
            {
                Crouch();
            }
            else
            {
                Stand();
                if (vertical == 1 || Input.GetKeyDown(KeyCode.Space))
                {
                    an.SetBool("Jumping", true);
                    Grounded = false;
                    StartCoroutine(Jump());
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                }
            }
        }
        else
        {
            an.SetBool("Grounded", false);
            if (vertical == -1)
            {
                an.SetBool("Gliding", true);
                rb.velocity = new Vector2(rb.velocity.x, -DownForce);
            }
        }
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(an.GetCurrentAnimatorStateInfo(0).length +
        an.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
    void HorizontalMov()
    {
        if (horizontal != 0)
        {
            dir = horizontal;
            an.SetBool("Running", true);
            rb.velocity = new Vector2(runSpeed * horizontal, rb.velocity.y);
            Scale.x = horizontal;
            transform.localScale = Scale;
        }
        else
        {
            an.SetBool("Running", false);
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
        an.SetBool("Running", false);
        sprite.transform.position = transform.position;
        BodyCollider.size = ogSize;
        BodyCollider.offset = Vector2.zero;
        weapon.transform.localPosition = weaponOgPos;
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