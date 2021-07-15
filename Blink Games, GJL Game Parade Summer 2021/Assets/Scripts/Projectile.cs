using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, lifeTime;
    public GameObject blood;
    float dir, damage;

    void Start()
    {
        transform.Rotate(0, 0, -90);
        lifeTime = 2;
        if (transform.tag == "PlayerWeapon")
        {
            damage = 5;
            dir = Player.dir;
        }
        else
        {
            //dir comes from enemies
            damage = 4;
        }
        //transform.position += Vector3.up * speed * Time.deltaTime * dir;
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Crates c = other.transform.GetComponent<Crates>();
            if (c)
            {
                c.Damage(damage);
                Destroy(gameObject);
            }
            else
            {
                //it hit the ground and do sound or effect idk
                Destroy(gameObject);
            }
        }
        else
        {
            if (damage == 5 && other.CompareTag("Player"))
            {
                Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            }
            else
            {
                GameObject effect = Instantiate(blood, transform.position + (Vector3.right * dir), blood.transform.rotation);
                //damage to player, enemies
                Destroy(gameObject);
            }
        }
    }
}