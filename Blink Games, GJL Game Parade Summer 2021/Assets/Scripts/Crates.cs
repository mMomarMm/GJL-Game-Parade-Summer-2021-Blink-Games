using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    public Animator a;
    float health = 25;
    public void Damage(float damage)
    {
        a.enabled = true;
        if (health > 0)
        {
            a.SetTrigger("wasShot");
            health -= damage;
        }
        else
        {
            a.ResetTrigger("wasShot");
            a.SetBool("Dead", true);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            Destroy(rb);
            Destroy(boxCollider2D);
            transform.position= Physics2D.Raycast(transform.position, Vector2.down).point;
            Destroy(this);
        }
    }
}