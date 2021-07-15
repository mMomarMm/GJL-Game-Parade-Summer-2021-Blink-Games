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
            health -= damage;
        }
        else
        {
            a.ResetTrigger("wasShot");
            a.SetBool("Dead", true);
            transform.position = new Vector2(transform.position.x, transform.position.y + .23f);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Destroy(rb);
            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            Destroy(boxCollider2D);
            Crates c = GetComponent<Crates>();
            Destroy(c);
        }
    }
}
