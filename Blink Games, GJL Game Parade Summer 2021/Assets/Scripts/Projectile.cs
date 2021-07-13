using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public bool stillAlive;
    public float lifeTime;

    void Start()
    {
        transform.Rotate(0, 0, -90);
        lifeTime = 2;
    }

    private void Update()
    {
        if (stillAlive == false)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        lifeTime -= 1 * Time.deltaTime;
        if (lifeTime > 0)
        {
            stillAlive = true;
        }
        else
        {
            stillAlive = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ground")){
            Destroy(gameObject);
        }
    }
}