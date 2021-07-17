using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, lifeTime, damage;
    public GameObject blood;
    public LayerMask ground;
    float dir;

    void Start()
    {
        lifeTime = 2;
        if (damage == 5)
        {
            dir = Player.dir;
        }
        else
        {
            //dir comes from enemies
        }
        //transform.position += Vector3.up * speed * Time.deltaTime * dir;
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * dir);
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
            if (other.CompareTag("Player")) damage = 0; //filler
            else
            {
                GameObject effect = Instantiate(blood, transform.position + Vector3.right, blood.transform.rotation);
                effect.transform.parent = other.gameObject.transform;
                //damage to player, enemies
                Destroy(gameObject);
            }
        }
    }
}