using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float vertical, horizontal;
    public float runSpeed, JumpForce, DownForce;
    Rigidbody2D rb;
    Animator an;
    LayerMask ground;
    public Vector2 crouchSize, weaponCrouchPos;
    public GameObject sprite, weapon;
    Vector3 Scale, ogSize, weaponOgPos;
    public BoxCollider2D BodyCollider;
    public static float dir, HealthPlayer; //looking direction

    void Start()
    {
        HealthPlayer = 100;
        ground = LayerMask.GetMask("Ground");
        weaponOgPos = new Vector2(0, -0.36f);
        an = GetComponentInChildren<Animator>();
        ogSize = BodyCollider.size;
        rb = GetComponent<Rigidbody2D>();
        Scale = Vector3.one;
    }

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        HorizontalMov();
        RaycastHit2D box = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - BodyCollider.size.y / 2),
                new Vector2(BodyCollider.size.x - .1f, .1f), 0, Vector2.right * dir, .1f, ground);
        if (box) // is touching ground)
        {
            an.SetBool("Grounded", true); an.SetBool("Gliding", false);
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
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                }
            }
        }
        else
        {
            an.SetBool("Grounded", false);
            if (vertical == -1)
            {
                an.SetBool("Jumping", false);
                an.SetBool("StartGlide", true);
                an.SetBool("Gliding", true);
                rb.velocity = new Vector2(rb.velocity.x * .8f, -DownForce);
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
    public IEnumerator Kill()
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
            yield return null;
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
}