using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, lifeTime, damage, dir;
    public GameObject blood;
    public LayerMask ground;
    GameObject effect;


    void Start()
    {
        lifeTime = 2;
        if (damage == 5)
        {
            dir = Player.dir;
        }        
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
        TakeDamage takeDamage = other.GetComponent<TakeDamage>();
        if (takeDamage != null)
        {
            if (!other.CompareTag("Ground"))
            {
                effect = Instantiate(blood, transform.position + Vector3.right, blood.transform.rotation);
                effect.transform.parent = other.gameObject.transform;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            takeDamage.Damage(damage, effect);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}